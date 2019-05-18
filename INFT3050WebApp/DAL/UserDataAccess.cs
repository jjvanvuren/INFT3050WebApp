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
            user.IsAdmin = (bool)reader.GetSqlBoolean(5);
            user.IsActive = (bool)reader.GetSqlBoolean(6);

            return user;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int CheckUser(string strEmail, string strPassword)
        {
            string sqlCheckAll = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive] 
                FROM[dbo].[webSiteUser] WHERE [email]=@strEmail AND [password]=@strPassword";

            string sqlCheckEmail = @"SELECT [userID], [email], [password], [firstName], [lastName], [isAdmin], [isActive] 
                FROM[dbo].[webSiteUser] WHERE [email]=@strEmail";



            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCheckAll, con))
                {
                    command.Parameters.Add(new SqlParameter("strEmail", strEmail));
                    command.Parameters.Add(new SqlParameter("strPassword", strPassword));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return 2;
                    }
                    else
                    {
                        using (SqlCommand commandEmail = new SqlCommand(sqlCheckEmail, con))
                        {
                            commandEmail.Parameters.Add(new SqlParameter("strEmail", strEmail));
                            con.Open();
                            SqlDataReader readerEmail = commandEmail.ExecuteReader();

                            if (readerEmail.HasRows)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserByEmail(string strEmail)
        {
            User users = new User();
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

        //[DataObjectMethod(DataObjectMethodType.Insert)]

    }
}