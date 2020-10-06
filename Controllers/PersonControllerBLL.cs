using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheet_Tracker.Models;

namespace Timesheet_Tracker.Controllers
{
    public class PersonController : Controller
    {
        // Using CRUD system to develop a BLL for PersonController

        // Create an account that accept name, password, username, and email

        public int Create(string username, string firstName,string lastName, string password, string email)
        {
            int target;

            // Call upon create password Hash to generate Hash and Salt for the password
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            Person newPerson = new Person()
            {
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DateCreated = DateTime.Today,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
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

        public Person Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            using (TimesheetContext context = new TimesheetContext())
            {
               Person returnUser = context.Persons.Where(x => x.Username == username).SingleOrDefault();

                // check if username exist
                if(returnUser == null) { return null;  }

                // check if password is correct
                if(!VerifyPasswordHash(password, returnUser.PasswordHash, returnUser.PasswordSalt)) { return null; }

                // authentication successful
                return returnUser;
            }

        }

        // Get a list of all person
        public List<Person> GetAllPerson()
        {
            List<Person> target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.ToList();
            }
            return target;
        }

        // Get a person by ID
        public Person GetPersonByID(int id)
        {
            Person target;
            using(TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.ID == id).SingleOrDefault();
            }
            return target;
        }

        // Get a person by name, first name and last name
        public Person GetPersonByName(string firstName, string lastName)
        {
            Person target;

            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.FirstName == firstName && x.LastName == lastName).SingleOrDefault();
            }
            return target;
        }

        // Get a person by email
        public Person GetPersonByEmail(string email)
        {
            Person target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.Email == email).SingleOrDefault();
            }
            return target;
        }

        // Get person by username
        public Person GetPersonByUsername(string username)
        {
            Person target;
            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.Username == username).SingleOrDefault();
            }
            return target;
        }

        // Update

        public Person UpdateAccount(int personID, string firstName, string lastName, string password, string username, string email)
        {
            Person target;
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            using (TimesheetContext context = new TimesheetContext())
            {
                target = context.Persons.Where(x => x.ID == personID).SingleOrDefault();
                target.FirstName = firstName;
                target.LastName = lastName;
                target.Username = username;
                target.Email = email;
                target.PasswordHash = passwordHash;
                target.PasswordSalt = passwordSalt;
                context.SaveChanges();
            }
            return target;
        }

        // Delete/Archive




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

    }
}
