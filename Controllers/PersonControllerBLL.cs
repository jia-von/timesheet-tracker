using System;
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
        // Add the app settings to the Personcontroller -JasonWatmore
        private readonly AppSettings _appSettings; 
        public PersonController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        // Using CRUD system to develop a BLL for PersonController

        // Create an account that accept name, password, username, and email

        public int Create(string firstName,string lastName, string password, string email, bool isInstructor)
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
            }

            // ensure the email has not been used for another account
            using (TimesheetContext context = new TimesheetContext())
            {
                if (context.Persons.Where(x => x.Email == email).Count() > 0)
                {
                    throw new ArgumentException("An account with the email provided already exists.");
                }
            }

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
        // Authetnntiate
        // return a personDTO whose authentication info matches or throw an error
        public PersonDTO Authenticate(string email, string password)
        {
            using (TimesheetContext context = new TimesheetContext())
            {
               Person returnUser = context.Persons.Where(x => x.Email == email && x.Archive == false).SingleOrDefault();

                // check if username exist
                if(returnUser == null) { return null;  }

                // if user isnt authenticated, return null
                if(!Hasher.ValidatePassword(password, returnUser.PasswordSalt, returnUser.PasswordHash))
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
                    new Claim(ClaimTypes.Role, "Instructor")// returnUser.Role) // TODO add string role field for users
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                
                //returnUser.Token = tokenHandler.WriteToken(token); // TODO add a string token field for user tokens varchar needs to be long (100?)

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

        // Get a list of all person
        public List<Person> GetAllPerson()
        {
            List<Person> target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.Archive == false).ToList();
            }
            return target;
        }

        // Get a person by ID
        public Person GetPersonByID(int id)
        {
            Person target;
            using(TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.ID == id && x.Archive == false).SingleOrDefault();
            }
            return target;
        }

        // Get a person by name, first name and last name
        public Person GetPersonByName(string firstName, string lastName)
        {
            Person target;

            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Archive == false).SingleOrDefault();
            }
            return target;
        }

        // Get a person by email
        public Person GetPersonByEmail(string email)
        {
            Person target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.Email == email && x.Archive == false).SingleOrDefault();
            }
            return target;
        }

        // Update
        public Person UpdateAccount(int personID, string firstName, string lastName, string password, string email)
        {
            Person target;
            var hashResult = Hasher.HashWithSalt(password);
            string passwordHash = hashResult["password"];
            string passwordSalt = hashResult["salt"];

            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.ID == personID).SingleOrDefault();
                target.FirstName = firstName;
                target.LastName = lastName;
                target.Email = email;
                target.PasswordHash = passwordHash;
                target.PasswordSalt = passwordSalt;
                context.SaveChanges();
            }
            return target;
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
                result = "User account successfully archived.";
            }
            return result;
        }


        /*
        // Below this line, all code blocks are methods to call upon, these accessors are all private. All of these codes are cited from Jason Watmore 

        // Create password hash @link: https://jasonwatmore.com/post/2020/01/10/react-aspnet-core-on-azure-with-sql-server-how-to-deploy-a-full-stack-app-to-microsoft-azure
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // Create authentication password
        private static bool VerifyPasswordHash (string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
        */

    }
}
