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
    public class PostageOptionDataAccess : IPostageOptionsDataAccess
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
            }
        }

        // Method used to create a postage option from reader data
        private static PostageOption CreatePostageOption(SqlDataReader reader)
        {
            PostageOption postageOption = new PostageOption();
            postageOption.Id = (int)reader["postageOptionID"];
            postageOption.Name = reader["postageOptionName"].ToString();
            postageOption.Price = (double)reader.GetDecimal(2);
            postageOption.IsActive = (bool)reader.GetSqlBoolean(3);

            return postageOption;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public PostageOption GetPostageOption(int PostageID)
        {
            PostageOption postageOption = new PostageOption();
            string sql = @"SELECT [postageOption].[postageOptionID], [postageOption].[postageOptionName], [postageOption].[shippingCost], [postageOption].[isActive]
                            FROM [dbo].[postageOption] 
                            WHERE postageOptionID = @ID;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    command.Parameters.AddWithValue("ID", PostageID);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                            postageOption = CreatePostageOption(reader);
                    }
                }
            }
            return postageOption;
        }

        // Method used to get all Postage Options
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable <PostageOption> GetPostageOptions()
        {
            List<PostageOption> postageOptions = new List<PostageOption>();
            string sql = @"SELECT [postageOption].[postageOptionID], [postageOption].[postageOptionName], [postageOption].[shippingCost], [postageOption].[isActive]
                            FROM [dbo].[postageOption] 
                            WHERE isActive = 1;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PostageOption newPostageOption = CreatePostageOption(reader);
                        postageOptions.Add(newPostageOption);
                    }
                }
            }
            return postageOptions;
        }

        //Method used to add a new postage option to the database
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int AddPostageOption(string Name, double Price)
        {
            string sql = @"INSERT INTO  dbo.[postageOption] VALUES (@Name, 0.00, @Price, 1);";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Price", Price);
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Method to "delete" a postage option in the database by changing isActive's value to 0
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int DeletePostageOptionById(int Id)
        {
            string sql = @"UPDATE dbo.[postageOption] SET [isActive] = 0
                            WHERE [postageOptionID]=@Id;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("Id", Id);
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Method to update a postage option in the database by Id
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdatePostageOptionById(int Id, double price, string name)
        {
            string sql = @"UPDATE dbo.[postageOption] SET [shippingCost] = @price, [postageOptionName] = @name
                            WHERE [postageOptionID]=@Id;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("Id", Id);
                    command.Parameters.AddWithValue("price", price);
                    command.Parameters.AddWithValue("name", name);
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

    }
}