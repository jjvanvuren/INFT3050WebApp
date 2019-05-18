using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public User() { }

        public User (int id, string email, string password, string firstName, string lastName, bool isAdmin, bool status)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsAdmin = isAdmin;
            this.IsActive = status;
        }

        
        public int CheckUser(string strEmail, string strPassword)
        {
            bool bCheckUserExists;
            string strDbPasswordHash;

            Regex rxEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            Regex rxPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?&_#^])[A-Za-z\d$@!%*?&_#^]{8,}");

            // Double check user email and password is in the valid format
            Match matchEmail = rxEmail.Match(strEmail);
            Match matchPassword = rxPassword.Match(strPassword);

            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            if (matchEmail.Success && matchPassword.Success)
            {
                bCheckUserExists = db.CheckUserExists(strEmail);

                if (bCheckUserExists)
                {
                    // Get the MD5 hash from DB
                    strDbPasswordHash = db.GetPasswordHash(strEmail);

                    using (MD5 md5Hash = MD5.Create())
                    {
                        // Verify entered password with DB
                        if (VerifyMd5Hash(md5Hash, strPassword, strDbPasswordHash))
                        {
                            return 2;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else if (matchEmail.Success && !matchPassword.Success)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
        // Get the MD5 Hash for a string
        static private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer and compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}