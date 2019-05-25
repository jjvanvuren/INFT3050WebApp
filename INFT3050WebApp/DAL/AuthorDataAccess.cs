using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.BL;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

namespace INFT3050WebApp.DAL
{
    public class AuthorDataAccess
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
            }
        }
        // Method used to get Authors by name
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Author> GetAuthors(string SearchFirstName, string SearchLastName)
        {

            List<Author> ListofAuthors = new List<Author>();
            string sql = @"SELECT *
                            FROM [dbo].[author]";
            if (SearchFirstName != null && SearchLastName != null)
            {
                sql=sql+" WHERE[author].[FirstName] = @FirstName AND[author].[LastName] = @LastName";
            }
            else if (SearchFirstName != null && SearchLastName == null)
            {
                sql = sql + " WHERE[author].[FirstName] = @FirstName";
            }
            else if (SearchFirstName == null && SearchLastName != null)
            {
                sql = sql + " WHERE[author].[LastName] = @LastName";
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    if (SearchFirstName != null)
                    {
                        command.Parameters.Add(new SqlParameter("FirstName", SearchFirstName));
                    }
                    if (SearchLastName != null)
                    {
                        command.Parameters.Add(new SqlParameter("LastName", SearchLastName));
                    }
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Author newAuthor = CreateAuthor(reader);
                        ListofAuthors.Add(newAuthor);
                    }
                }
            }
            return ListofAuthors;
        }


        public Author getAuthor(string SearchFirstName, string SearchLastName)
        {
            string sql = @"SELECT *
                            FROM [dbo].[author]
                            WHERE[author].[FirstName] = @FirstName AND[author].[LastName] = @LastName";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("FirstName", SearchFirstName));
                    command.Parameters.Add(new SqlParameter("LastName", SearchLastName));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Author Author = CreateAuthor(reader);
                        return Author;
                    }
                }
            }
            return null;
        }

        public void AddAuthor(int id, string SearchFirstName, string SearchLastName)
        {
            string sql = @"INSERT INTO author ([ID], City, Country)
                            SELECT SupplierName, City, Country FROM Suppliers";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("FirstName", SearchFirstName));
                    command.Parameters.Add(new SqlParameter("LastName", SearchLastName));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Author Author = CreateAuthor(reader);
                        
                    }
                }
            }
            
        }
        


        // Method used to create Author object from the reader
        private static Author CreateAuthor(SqlDataReader reader)
        {
            Author author = new Author();
            author.Id = (int)reader["authorID"];
            author.Description = (string)reader.GetSqlString(3);
            author.FirstName = (string)reader.GetSqlString(1);
            author.LastName = (string)reader.GetSqlString(2);

            return author;
        }
    }
}