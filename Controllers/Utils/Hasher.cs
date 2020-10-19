using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Timesheet_Tracker.Controllers.Utils
{
    public static class Hasher
    {
        // Template from ASP.NET Core 3.1 - Simple API for Authentication, Registration and User Management @link: https://jasonwatmore.com/post/2019/10/14/aspnet-core-3-simple-api-for-authentication-registration-and-user-management
        public static Dictionary<string, string> HashWithSalt(string password)
        {
            // create an instance of the crypto service provider
            RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            // create a 10 byte long byte array
            byte[] salt = new byte[6];
            // use the crypto service provider to fill the byte array with crytographically strong random values
            saltGenerator.GetBytes(salt);

            // store the provided password in a byte array
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);

            // we will prefix our password with the salt then hash
            // create a byte array equal to password and salt length
            byte[] hashInput = new byte[salt.Length + passwordBytes.Length];
            // loop through and input the salt & password bytes into the array
            for (int i = 0; i < salt.Length; i++)
            {
                hashInput[i] = salt[i];
            }
            for (int i = salt.Length; i < hashInput.Length; i++)
            {
                hashInput[i] = passwordBytes[i - salt.Length];
            }

            // hash the combined Salt+Password array
            SHA512 hashGenerator = new SHA512Managed();
            byte[] hashedPassword = hashGenerator.ComputeHash(hashInput);

            // convert the salt and hashedpassword to string values
            // we use Convert.ToBase64String() to capture random bytes and enable decoding string -> bytes with Convert.FromBase64String
            string hashedPasswordString = Convert.ToBase64String(hashedPassword);
            string saltString = Convert.ToBase64String(salt);

            // return a dictionary with k v pairs for the salt and password hash
            return new Dictionary<string, string>()
            {
                { "salt", saltString },
                { "password", hashedPasswordString }
            };
        }

        // returns true if password is valid else returns false
        public static bool ValidatePassword(string passwordPlainText, string salt, string passwordHashed )
        {
            // convert all values back to byte strings
            // the encoders used must match the encoders used while creating the password hash
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(passwordPlainText);

            // concatenate the salt and pasword bytes
            List<Byte> saltyPassword = new List<Byte>();
            saltyPassword.AddRange(saltBytes);
            saltyPassword.AddRange(passwordBytes);
            byte[] saltyPasswordBytes = saltyPassword.ToArray();

            // hash the salt+password mix
            SHA512 hashGenerator = new SHA512Managed();
            return passwordHashed == Convert.ToBase64String(hashGenerator.ComputeHash(saltyPasswordBytes));
        }
    }
}
