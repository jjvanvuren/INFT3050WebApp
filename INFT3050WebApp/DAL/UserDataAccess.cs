using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    [DataObject(true)]
    public class UserDataAccess : IUserDataAccess
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
            }
        }


        // Used to create a user from the attributes read by the SqlDataReader
        private static User CreateUser(SqlDataReader reader)
        {
            User user = new User();
            user.Id = (int)reader["userID"];
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.IsAdmin = (bool)reader.GetSqlBoolean(5);
            user.IsActive = (bool)reader.GetSqlBoolean(6);

            return user;
        }

        // Used to check if the user exists on the DB using their email address
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool CheckUserExists(string strEmail)
        {
            string sql = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive]
                FROM[dbo].[webSiteUser] WHERE [email]=@strEmail";

            User checkUser = new User
            {
                Id = 0,
                IsActive = false
            };

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("strEmail", strEmail));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        checkUser.Id = (int)reader["userID"];
                        checkUser.IsActive = (bool)reader.GetSqlBoolean(6);
                    }

                    // Check if the reader returned a valid Id
                    // Also check if the user is marked as active in the DB
                    if (checkUser.Id != 0 && checkUser.IsActive)
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

        // Used to return a User object using their email address
        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserByEmail(string strEmail)
        {
            string sql = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive]
                FROM[dbo].[webSiteUser] WHERE [email]=@Email";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Email", strEmail));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User newUser = CreateUser(reader);

                        return newUser;
                    }
                }
            }
            return null;
        }

        // Used to return a User object using their Primary key ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserById(int Id)
        {
            string sql = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive]
                FROM[dbo].[webSiteUser] WHERE [userID]=@Id";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", Id));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        User newUser = CreateUser(reader);

                        return newUser;
                    }
                }
            }
            return null;
        }

        // Finds and returns the user's Hashed password using the user's email address
        [DataObjectMethod(DataObjectMethodType.Select)]
        public string GetPasswordHash(string strEmail)
        {
            string strPasswordHash;

            string sql = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive]
                FROM[dbo].[webSiteUser] WHERE [email]=@Email";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Email", strEmail));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User newUser = CreateUser(reader);

                        strPasswordHash = newUser.Password;

                        return strPasswordHash;
                    }
                }
            }
            return null;
        }

        // Creates a new user in the DB using a User object
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int RegisterUser(User user)
        {
            string sql = @"INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES (@email, @password, @firstName, @lastName, @isAdmin, 1);";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    int iIsAdmin;

                    if (user.IsAdmin)
                    {
                        iIsAdmin = 1;
                    }
                    else
                    {
                        iIsAdmin = 0;
                    }

                    command.Parameters.AddWithValue("email", user.Email);
                    command.Parameters.AddWithValue("password", user.Password);
                    command.Parameters.AddWithValue("firstName", user.FirstName);
                    command.Parameters.AddWithValue("lastName", user.LastName);
                    command.Parameters.AddWithValue("isAdmin", iIsAdmin.ToString());
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}