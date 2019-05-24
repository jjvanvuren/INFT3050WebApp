﻿using System;
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
            postageOption.Price = (double)reader["shippingCost"];
            postageOption.IsActive = (bool)reader.GetSqlBoolean(3);

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
    }
}