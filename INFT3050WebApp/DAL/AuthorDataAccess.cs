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

        //Adding an Author to the database
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddAuthor(string SearchFirstName, string SearchLastName, string newDecription)
        {
            string sql = @"INSERT INTO author (FirstName, LastName, description)
                            VALUES (@FirstName, @LastName, @description)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("FirstName", SearchFirstName));
                    command.Parameters.Add(new SqlParameter("LastName", SearchLastName));
                    command.Parameters.Add(new SqlParameter("description", newDecription));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Author Author = CreateAuthor(reader);

                    }
                }
            }

        }


        //getting an Author by ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Author getAuthor(int ID)
        {
            string sql = @"SELECT *
                            FROM [dbo].[author]
                            WHERE[author].[authorID] = @ID";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("ID", ID));

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
        
        //getting a list of authors by Book ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Author> getAuthors(int BookID)
        {
            List<Author> listofAuthors = new List<Author>();
            string sql = @"SELECT [author].[authorID], [author].[firstName], [author].[lastName],[author].[description]
                            FROM [dbo].[bookAuthor]
                            INNER JOIN [author] ON [bookAuthor].[authorID] = [author].[authorID]
                            WHERE[bookAuthor].[itemID] = @itemID ";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("itemID", BookID));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Author Author = CreateAuthor(reader);
                        listofAuthors.Add(Author);
                    }
                    return listofAuthors;
                }
            } 
        }


        //get an author by Name (might delete this one)(use of this was sloppy)
        [DataObjectMethod(DataObjectMethodType.Select)]
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
       

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void ConnectBookAuthor(int BookID, List<Author> Authors)
        {
            string sql = @"INSERT INTO bookAuthor (itemID, authorID)
                            VALUES(@itemID, @authorID)";
            if (Authors.Count > 1) {
                foreach (Author bookAuthors in Authors)
                {
                    sql = sql + ",(@itemID, @authorID)";
                }
            }
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    for (int i = 0; i < Authors.Count; ++i)
                    {
                        command.Parameters.Add(new SqlParameter("itemID", BookID));
                        command.Parameters.Add(new SqlParameter("authorID", Authors[i].Id));
                    }
                    con.Open();
                    command.ExecuteNonQuery();
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