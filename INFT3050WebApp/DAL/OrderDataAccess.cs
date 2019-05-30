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
    public class OrderDataAccess : IOrderDataAccess
    {

        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
            }
        }

        // Method used to create Order object from the reader
        private static Order CreateOrder(SqlDataReader reader)
        {
            Order order = new Order();
            order.orderId = (int)reader["orderID"];
            order.userId = (int)reader["userID"];
            order.paymentId = (int)reader["paymentID"];
            order.postageOptionId = (int)reader["postageOptionID"];
            order.GST = (int)reader["GST"];
            order.Total = (double)reader.GetDecimal(6);
            order.dateOrdered = (DateTime)reader["dateOrdered"];

            return order;
        }

        // Method used to get orders by userID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Order> GetOrdersByUserID(int Id)
        {
            List<Order> orders = new List<Order>();
            string sql = @"SELECT [orderID], [userID], [paymentID], [postageOptionID], [orderStatus], [GST], [subTotal], [dateOrdered]
                FROM[dbo].[orders]
                WHERE [userID] = @Id;";

            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("Id", Id);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        Order newOrder = CreateOrder(reader);
                        orders.Add(newOrder);
                    }
                }
            }
            return orders;
        }

    }
}