using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Mail;
using INFT3050WebApp.DAL;
using System.Configuration;

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
        public string ValidationKey { get; set; }
        public bool IsVerified { get; set; }

        public User() { }

        // Constructor that hashes the password with MD5 before creating the User
        public User (string email, string password, string firstName, string lastName, bool isAdmin, bool isActive, string validationKey, bool isVerified)
        {
            // Hash the plain text password using md5Hash
            using (MD5 md5Hash = MD5.Create())
            {
                string passwordHash = GetMd5Hash(md5Hash, password);

                this.Password = passwordHash;
            }

            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsAdmin = isAdmin;
            this.IsActive = isActive;
            this.ValidationKey = validationKey;
            this.IsVerified = isVerified;
        }

        // Constructor that creates a user using data from DB using the user's email
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
            this.ValidationKey = user.ValidationKey;
            this.IsVerified = user.IsVerified;
        }

        // Constructor that creates a user using data from DB using the user's
        // Primary Key ID
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
            this.ValidationKey = user.ValidationKey;
            this.IsVerified = user.IsVerified;
        }

        // Method to get all users from database
        public List<User> GetAllUsers()
        {
            var db = new UserDataAccess();
            var users = db.GetUsers();

            List<User> allUsers = new List<User>();

            foreach (User user in users)
            {
                allUsers.Add(user);
            }

            return allUsers;
        }

        // Deactivate a user by their ID
        public int DeactivateUserById(int Id)
        {

            var db = new UserDataAccess();

            int rowsAffected = db.DeactivateUserById(Id);

            return rowsAffected;
        }

        // Activate a user by their ID
        public int ActivateUserById(int Id)
        {

            var db = new UserDataAccess();

            int rowsAffected = db.ActivateUserById(Id);

            return rowsAffected;
        }

        // Verifies if user ValidationKey is a match
        public bool Verify(string strEmail, string strKey)
        {
            User user = new User(strEmail);

            if (user.Email == strEmail && user.ValidationKey == strKey)
            {
                // Setup access to database
                IUserDataAccess db = new UserDataAccess();

                int iVerified = db.VerifyUser(user);
                
                if (iVerified == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Generate a ValidationKey for the user
        public void GenValidationKey()
        {
            // https://stackoverflow.com/questions/730268/unique-random-string-generation
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            this.ValidationKey = GuidString;
        }

        // Method that checks if the user's Email and password meets requirements
        // and checks if the email and password match what's on the DB
        public int CheckLoginUser(string strEmail, string strPassword)
        {
            bool bVerified;
            int iRequirements = RequirementsCheck(strEmail, strPassword);

            int iCheckUser = CheckUser(strEmail, strPassword);

            
            if (iCheckUser == 0)
            {
                // No need to check if user is verified if they don't exist
                bVerified = false;
            }
            else
            {
                // If the user exists, check if they are verified
                bVerified = LoginVerify(strEmail);
            }

            // Return 0 if the email doesn't meet requirements or doesn't exist in DB
            if (iCheckUser == 0 || iRequirements == 0)
            {
                return 0;
            }
            // Return 1 if the email is correct but the password isn't
            else if (iCheckUser == 1 || iRequirements == 1)
            {
                return 1;
            }
            // if user isn't verified
            else if (!bVerified)
            {
                return 3;
            }
            // Return 2 if both email and password is correct
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

        // Checks that a User exists on the DB and that the email and password
        // matches strEmail and the MD5 hash of strPassword
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

        // Method that creates a new admin in the DB and sends an email
        // for verification
        public void RegisterNewAdmin(User uNewUser)
        {
            const string strSubject = "Used Books Website Administrator Validation";
            string strEmailFormat;
            string strBody;
            string strBaseUrl = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminVerified.aspx";

            // Generate the Validation Key
            uNewUser.GenValidationKey();

            // Create Validation URL
            string strValidationUrl = strBaseUrl + "?email=" + uNewUser.Email + "&key=" + uNewUser.ValidationKey;

            // Format the email body depending on if user has a lastname
            if (uNewUser.LastName == "")
            {
                strEmailFormat = "Hi {0},\n\rYou have successfuly registered as an administrator at UsedBooks.com.au!\n\r" +
                "Please click on the link below to verify your account.\n\r {1}";

                strBody = string.Format(strEmailFormat, uNewUser.FirstName, strValidationUrl);
            }
            else
            {
                strEmailFormat = "Hi {0} {1},\n\rYou have successfuly registered as an administrator at UsedBooks.com.au!\n\r" +
                "Please click on the link below to verify your account.\n\r{2}";

                strBody = string.Format(strEmailFormat, uNewUser.FirstName, uNewUser.LastName, strValidationUrl);
            }

            // Add the admin user to the DB and send confirmation email
            RegisterNewUser(uNewUser);
            SendEmail("donotreply@usedbooksales.com.au", "UsedBooks.com.au", uNewUser.Email, strSubject, strBody);
        }

        // Method that sends an email
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

        //Checks if user has verified via email
        private bool LoginVerify(string strEmail)
        {
            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            User user = new User(strEmail);

            if (user.IsVerified)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Send payment confirmation
        public void SendPaymentEmail(int iUserId, int iPaymentId)
        {
            //Get user by their ID
            User user = new User(iUserId);

            // Setup access to database
            IOrderDataAccess db = new OrderDataAccess();

            // Get the newly created order details
            Order order = db.GetOrder(iPaymentId);

            const string strSubject = "Used Books Payment Confirmation";
            string strEmailFormat;
            string strBody;

            // Format the email body depending on if user has a lastname
            if (user.LastName == "")
            {
                strEmailFormat = "Hi {0},\n\rThank you for shopping with us! Your payment of ${1} has been accepted.\n\r" +
                    "Your order number is: {2}. You will receive another email containing tracking information once your order has been shipped.";

                strBody = string.Format(strEmailFormat, user.FirstName, order.Total.ToString(), order.orderId.ToString());
            }
            else
            {
                strEmailFormat = "Hi {0} {1},\n\rThank you for shopping with us! Your payment of ${2} has been accepted.\n\r" +
                    "Your order number is: {3}. You will receive another email containing tracking information once your order has been shipped.";

                strBody = string.Format(strEmailFormat, user.FirstName, user.LastName, order.Total.ToString(), order.orderId.ToString());
            }

            // Send payment confirmation email
            SendEmail("donotreply@usedbooksales.com.au", "UsedBooks.com.au", user.Email, strSubject, strBody);
        }

        // Send the password reset email to the user.
        public void SendResetPassword(string strEmail)
        {
            User updateUser = new User();

            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            updateUser.Email = strEmail;

            updateUser.GenValidationKey();

            db.UpdateKey(updateUser);

            User user = new User(strEmail);

            const string strSubject = "Used Books Password Recovery";
            string strEmailFormat;
            string strBody;
            string strBaseUrl = ConfigurationManager.AppSettings["SecurePath"] + "UL/NewPassword.aspx";

            // Create Validation URL
            string strResetUrl = strBaseUrl + "?email=" + user.Email + "&key=" + user.ValidationKey;

            // Format the email body depending on if user has a lastname
            if (user.LastName == "")
            {
                strEmailFormat = "Hi {0},\n\rPlease click on the link below to reset your password.\n\r{1}";

                strBody = string.Format(strEmailFormat, user.FirstName, strResetUrl);
            }
            else
            {
                strEmailFormat = "Hi {0} {1},\n\rPlease click on the link below to reset your password.\n\r{2}";

                strBody = string.Format(strEmailFormat, user.FirstName, user.LastName, strResetUrl);
            }

            // Send password recovery email
            SendEmail("donotreply@usedbooksales.com.au", "UsedBooks.com.au", user.Email, strSubject, strBody);
        }

        public void ResetPassword()
        {
            User user = new User(this.Email);

            // Hash the plain text password using md5Hash
            using (MD5 md5Hash = MD5.Create())
            {
                string passwordHash = GetMd5Hash(md5Hash, this.Password);

                this.Password = passwordHash;
            }

            user.Password = this.Password;

            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            int iUpdatePassword = db.UpdatePassword(user);

            // Blank out ValidationKey so that same
            // Password reset link cannot be used again
            user.ValidationKey = "";
            db.UpdateKey(user);
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