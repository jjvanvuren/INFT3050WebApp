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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            string sql = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive] FROM[dbo].[webSiteUser]";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User newUser = CreateUser(reader);
                        users.Add(newUser);
                    }
                }
            }
            return users;
        }
                
        private static User CreateUser(SqlDataReader reader)
        {
            User user = new User();
            user.Id = (int)reader["userID"];
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.IsAdmin = (int)reader["isAdmin"];
            user.IsActive = (int)reader["isActive"];

            return user;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserByEmail(string strEmail)
        {
            List<User> users = new List<User>();
            string sql = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive] 
                FROM[dbo].[webSiteUser] WHERE [email]=@Email";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Email", strEmail));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return CreateUser(reader);
                    }
                }
            }
            return null;
        }
    }
}