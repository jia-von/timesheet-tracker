﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Timesheet_Tracker.Controllers.Utils;
using Timesheet_Tracker.Models;
using Timesheet_Tracker.Models.DTO;

namespace Timesheet_Tracker.Controllers
{
    public class PersonController : Controller
    {
        // This template is from 4.1-ReactAPI project @link: https://github.com/TECHCareers-by-Manpower/4.1-ReactAPI/tree/master/Controllers
        // Add the app settings to the Personcontroller -JasonWatmore @link: https://jasonwatmore.com/post/2019/10/16/aspnet-core-3-role-based-authorization-tutorial-with-example-api#authenticate-model-cs
        private readonly AppSettings _appSettings;
        public PersonController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        // Create an account that accept name, password, username, and email

        public int Create(string firstName, string lastName, string password, string email, bool isInstructor)
        {

            // validate the inputs
            switch (true)
            {
                case bool _ when firstName == "":
                    throw new ArgumentException("First Name cannot be an empty string");
                case bool _ when Regex.IsMatch(firstName, @"[0-9]"):
                    throw new ArgumentException("First Name cannot contain any numbers");
                case bool _ when firstName.Length > 50:
                    throw new ArgumentException("First Name cannot be more than 50 characters long");

                case bool _ when lastName == "":
                    throw new ArgumentException("Last Name cannot be an empty string");
                case bool _ when Regex.IsMatch(lastName, @"[0-9]"):
                    throw new ArgumentException("Last Name cannot contain any numbers");
                case bool _ when lastName.Length > 50:
                    throw new ArgumentException("Last Name cannot be more than 50 characters long");

                case bool _ when password == "":
                    throw new ArgumentException("Password cannot be an empty string");
                case bool _ when password.Length < 6:
                    throw new ArgumentException("Minimum Password length is 6 characters long");
                case bool _ when password.Length > 50:
                    throw new ArgumentException("Password cannot be more than 50 characters long");

                case bool _ when email == "":
                    throw new ArgumentException("Email cannot be an empty string");
                case bool _ when !Regex.IsMatch(email, @"[@]"):
                    throw new ArgumentException("Invalid email. Ensure you have email@email.tld format");
                case bool _ when password.Length > 50:
                    throw new ArgumentException("Email cannot be more than 50 characters long");

                default:
                    break;
            }

            // ensure the email has not been used for another account
            using (TimesheetContext context = new TimesheetContext())
            {
                if (context.Persons.Where(x => x.Email == email).Count() > 0)
                {
                    throw new ArgumentException("An account with the email provided already exists.");
                }
            }

            // create an int to store the new user id
            int target;

            // Call upon create password Hash to generate Hash and Salt for the password
            var hashResult = Hasher.HashWithSalt(password);
            string passwordHash = hashResult["password"];
            string passwordSalt = hashResult["salt"];

            Person newPerson = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DateCreated = DateTime.Today,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Archive = false,
                Role = isInstructor ? Roles.Instructor : Roles.Student
            };

            using (TimesheetContext context = new TimesheetContext())
            {
                context.Persons.Add(newPerson);
                context.SaveChanges();
                target = newPerson.ID;
            }
            return target;
        }

        // READ
        // Authenticate
        // return a personDTO whose authentication info matches or throw an error
        public PersonDTO Authenticate(string email, string password)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
                Person returnUser = context.Persons.Where(x => x.Email == email && x.Archive == false).SingleOrDefault();

                // check if username exist
                if (returnUser == null) { return null; }

                // if user isnt authenticated, return null
                if (!Hasher.ValidatePassword(password, returnUser.PasswordSalt, returnUser.PasswordHash))
                {
                    return null;
                }

                // if we get to this point, then the user was authenticated
                // create a JWT token and add it to the user
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, returnUser.ID.ToString()),
                    new Claim(ClaimTypes.Role,  returnUser.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);


                PersonDTO authenticatedUser = new PersonDTO()
                {
                    ID = returnUser.ID,
                    Email = returnUser.Email,
                    FirstName = returnUser.FirstName,
                    LastName = returnUser.LastName,
                    //Cohort = employeeInfo.Cohort,
                    //Instructor = employeeInfo.Instructor,
                    //Projects = GET a list of projects belonging to this person,
                    Token = tokenHandler.WriteToken(token)
                };

                // authentication successful
                return authenticatedUser;
            }

        }

        // Update
        public string UpdateAccount(int personID, string firstName, string lastName, string currentPassword, string newPassword, bool updatePassword)
        {
            // validate the inputs
            switch (true)
            {
                case bool _ when firstName == "":
                    throw new ArgumentException("First Name cannot be an empty string");
                case bool _ when Regex.IsMatch(firstName, @"[0-9]"):
                    throw new ArgumentException("First Name cannot contain any numbers");
                case bool _ when firstName.Length > 50:
                    throw new ArgumentException("First Name cannot be more than 50 characters long");

                case bool _ when lastName == "":
                    throw new ArgumentException("Last Name cannot be an empty string");
                case bool _ when Regex.IsMatch(lastName, @"[0-9]"):
                    throw new ArgumentException("Last Name cannot contain any numbers");
                case bool _ when lastName.Length > 50:
                    throw new ArgumentException("Last Name cannot be more than 50 characters long");

                case bool _ when currentPassword == "":
                    throw new ArgumentException("Password cannot be an empty string");

                case bool _ when newPassword == "":
                    throw new ArgumentException("Password cannot be an empty string");
                case bool _ when newPassword.Length < 6:
                    throw new ArgumentException("Minimum Password length is 6 characters long");
                case bool _ when newPassword.Length > 50:
                    throw new ArgumentException("Password cannot be more than 50 characters long");

                default:
                    break;
            }

            string passwordHash = "";
            string passwordSalt = "";
            // make a hash and salt with the new password if we want to change password
            if (updatePassword)
            {
                var hashResult = Hasher.HashWithSalt(newPassword);
                passwordHash = hashResult["password"];
                passwordSalt = hashResult["salt"];
            }

            using (TimesheetContext context = new TimesheetContext())
            {
                Person person = context.Persons.Where(x => x.ID == personID).SingleOrDefault();
                if (person == null) { throw new Exception($"Person with ID: {personID} was not found."); }

                // confirm if the provided password matches this user's existing one
                if (updatePassword && !Hasher.ValidatePassword(currentPassword, person.PasswordSalt, person.PasswordHash))
                {
                    throw new Exception($"Invalid Password.");
                }

                person.FirstName = firstName;
                person.LastName = lastName;
                // change salt and hash ony if we want to update password
                if (updatePassword)
                {
                    person.PasswordHash = passwordHash;
                    person.PasswordSalt = passwordSalt;
                }
                context.SaveChanges();
            }
            return "Successfully updated account";
        }

        // Delete/Archive
        public string DeletePersonByID(int id)
        {
            string result;
            using (TimesheetContext context = new TimesheetContext())
            {
                // archive this person throw error if they arent found
                Person target = context.Persons.Where(x => x.ID == id && x.Archive == false).SingleOrDefault();
                if (target == null)
                {
                    throw new Exception($"Person with ID: {id} was not found.");
                }
                target.Archive = true;
                // archive this persons employee record
                Employee targetEmployee = context.Employees.Where(x => x.PersonID == target.ID).SingleOrDefault();
                targetEmployee.Archive = true;
                // loop through and archive all projects for this person
                List<Project> targetProjects = context.Projects.Where(x => x.EmployeeID == targetEmployee.ID).ToList();
                foreach (Project targetProject in targetProjects)
                {
                    targetProject.Archive = true;
                }
                context.SaveChanges();
                result = "Your account has been archived. We may store data for records (this will not be publicly available)";
            }
            return result;
        }

    }
}
