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
    public class CategoryDataAccess : ICategoryDataAccess
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
            }
        }

        // Method used to create Category object from the reader
        private static Category CreateCategory(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = (int)reader["categoryID"];
            category.Name = (string)reader.GetSqlString(1);
            category.Description = (string)reader.GetSqlString(2);

            return category;
        }

        //Gets a list of all categories
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> GetCategory()
        {
            List<Category> ListofCategory = new List<Category>();
            string sql = @"SELECT [categoryID], [name], [description] 
                            FROM [dbo].[category]";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category newCategory = CreateCategory(reader);
                        ListofCategory.Add(newCategory);
                        
                    }
                    
                }
            }
            return ListofCategory;
        }

        // Method used to get a Category by ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Category GetCategoryById(int Id)
        {
            string sql = @"SELECT [categoryID], [name], [description] 
                            FROM [dbo].[category] 
                            WHERE [categoryID]=@Id;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", Id));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category newCategory = CreateCategory(reader);

                        return newCategory;
                    }
                }
            }
            return null;
        }

        //Methord adding one or multiple authors to  bookCategory Table at once in the data base
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void ConnectBookCategory(int BookID, List<Category> Categories)
        {
            string sql = @"INSERT INTO bookCategory ([itemID], [categoryID]) VALUES";
            //Creating a Values section for each instance of Categories with unquie IDs for inserting.
            int i = 0;
            foreach (Category category in Categories)
            {
                sql = sql + "(@itemID" + i.ToString() + ", @CategoryID" + i.ToString() + ")";
                if (Categories.Count == 1 || Categories.IndexOf(category) == Categories.Count - 1)
                {

                }
                else
                {
                    sql += ", ";
                }
                i++;
            }
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    //adding both Item ID and categoryID to each unquie ID in the SQL string for inserting.
                    int j = 0;
                    foreach (Category category in Categories)
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("itemID" + j.ToString(), BookID);
                        command.Parameters.AddWithValue("CategoryID" + j.ToString(), category.Id);
                        j++;
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        //getting a list of authors by Book ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> getCategories(int BookID)
        {
            List<Category> listofCategories = new List<Category>();
            string sql = @"SELECT [category].[categoryID], [category].[Name],[category].[description]
                            FROM [dbo].[bookCategory]                   
                            INNER JOIN [category] ON [bookCategory].[categoryID] = [category].[categoryID]
                            WHERE[bookCategory].[itemID] = @itemID ";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("itemID", BookID));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category catergory = CreateCategory(reader);
                        listofCategories.Add(catergory);
                    }
                    return listofCategories;
                }
            }
        }
    }
}