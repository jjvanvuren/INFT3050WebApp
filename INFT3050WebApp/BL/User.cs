using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Mail;
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

        public User (string email, string password, string firstName, string lastName, bool isAdmin, bool status)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string passwordHash = GetMd5Hash(md5Hash, password);

                this.Password = passwordHash;
            }
                
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsAdmin = isAdmin;
            this.IsActive = status;
        }

        public User (string strEmail)
        {
            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            User user = db.GetUserByEmail(strEmail);

            this.Id = user.Id;
            this.Email = user.Email;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.IsAdmin = user.IsAdmin;
            this.IsActive = user.IsActive;
        }

        public User(int iUserId)
        {
            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            User user = db.GetUserById(iUserId);

            this.Id = user.Id;
            this.Email = user.Email;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.IsAdmin = user.IsAdmin;
            this.IsActive = user.IsActive;
        }

        public int CheckLoginUser(string strEmail, string strPassword)
        {
            int iRequirements = RequirementsCheck(strEmail, strPassword);

            int iCheckUser = CheckUser(strEmail, strPassword);

            if (iCheckUser == 0 || iRequirements == 0)
            {
                return 0;
            }
            else if (iCheckUser == 1 || iRequirements == 1)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        // Checks the database and:
        // Returns 2 if email does not exist and both email and password requirements are met
        // Returns 1 if password requirements are not met
        // Returns 0 if email requirements are not met or email already exists in DB
        public int CheckRegisterUser(string strEmail, string strPassword)
        {
            int iRequirements = RequirementsCheck(strEmail, strPassword);

            int iCheckUser = CheckUser(strEmail, strPassword);

            if (iRequirements == 0)
            {
                return 0;
            }
            else if (iRequirements == 1)
            {

                return 1;
            }
            else
            {
                if (iCheckUser == 2 || iCheckUser == 1)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
        }

        private int CheckUser(string strEmail, string strPassword)
        {
            bool bCheckUserExists;
            string strDbPasswordHash;

            // Check if the user exists in the DB
            bCheckUserExists = UserExists(strEmail);

            if (bCheckUserExists)
            {
                // Setup access to database
                IUserDataAccess db = new UserDataAccess();

                // Get the MD5 hash from DB
                strDbPasswordHash = db.GetPasswordHash(strEmail);

                // Verify entered password with DB
                using (MD5 md5Hash = MD5.Create())
                {
                    // Both email and password match DB
                    if (VerifyMd5Hash(md5Hash, strPassword, strDbPasswordHash))
                    {
                        return 2;
                    }
                    // Password doesn't match DB
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

        // Double check user email and password is in the valid format using Regex
        private int RequirementsCheck (string strEmail, string strPassword)
        {
            Regex rxEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            Regex rxPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@!%*?&_#^])[A-Za-z\d$@!%*?&_#^]{8,}");

            Match matchEmail = rxEmail.Match(strEmail);
            Match matchPassword = rxPassword.Match(strPassword);

            if (!matchEmail.Success)
            {
                return 0;
            }
            else if (matchEmail.Success && !matchPassword.Success)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        // Used to check if the user exists in the database using their email address
        public bool UserExists (string strEmail)
        {
            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            // Check if the user exists in the DB
            bool bUserExists = db.CheckUserExists(strEmail);

            return bUserExists;
        }

        public void RegisterNewUser(User uNewUser)
        {
            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            int rowsAffected = db.RegisterUser(uNewUser);
        }

        public void RegisterNewAdmin(User uNewUser)
        {
            const string strSubject = "Used Books Website Administrator Confirmation";
            string strEmailFormat;
            string strBody;

            // Format the email body depending on if user has a lastname
            if (uNewUser.LastName == "")
            {
                strEmailFormat = "Hi {0},\n\rYou have successfuly registered as an administrator at UsedBooks.com.au!\n\r" +
                "If this was not you, please contact us at support@usedbooksales.com.au.";

                strBody = string.Format(strEmailFormat, uNewUser.FirstName);
            }
            else
            {
                strEmailFormat = "Hi {0} {1},\n\rYou have successfuly registered as an administrator at UsedBooks.com.au!\n\r" +
                "If this was not you, please contact us at support@usedbooksales.com.au.";

                strBody = string.Format(strEmailFormat, uNewUser.FirstName, uNewUser.LastName);
            }

            // Add the admin user to the DB and send confirmation email
            RegisterNewUser(uNewUser);
            SendEmail("donotreply@usedbooksales.com.au", "UsedBooks.com.au", uNewUser.Email, strSubject, strBody);
        }

        

        private void SendEmail(string strFromAddress, string strFromName, string strToAddress,
            string strSubject, string strBody)
        {
            MailAddress fromAdd = new MailAddress(strFromAddress, strFromName);
            MailAddress toAdd = new MailAddress(strToAddress);
            MailMessage msg = new MailMessage(fromAdd, toAdd);
            msg.Subject = strSubject;
            msg.Body = strBody;

            SmtpClient client = new SmtpClient();
            client.Send(msg);
        }

        // Get the MD5 Hash for a string. Used for the user password
        // Method sourced from https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
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