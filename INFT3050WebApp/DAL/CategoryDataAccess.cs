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

        // Method used to create Category object from the reader
        private static Category CreateCategory(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = (int)reader["categoryID"];
            category.Name = reader["name"].ToString();
            category.Description = reader["description"].ToString();

            return category;
        }
    }
}