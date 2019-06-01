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

        // Method used to get an order by user ID & payment ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Order GetOrder(int iPaymentId, int iUserId)
        {
            Order order = new Order();

            string sql = @"SELECT [orderID], [userID], [paymentID], [postageOptionID], [orderStatus], [GST], [subTotal], [dateOrdered]
                FROM[dbo].[orders]
                WHERE [userID] = @uId & [paymentID] = @pId;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("uId", iUserId);
                    command.Parameters.AddWithValue("pId", iPaymentId);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        order = CreateOrder(reader);
                    }
                }
            }
            return order;
        }


        //methord for adding order to the database
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int submitCart(int userID, Address userAddress, int ipostageOptionID, List<CartItem> Cart,double dTotalPrice, DateTime PurchaseTime)
        {   //this should be in a StoredProcedure didnt have time to do this
            //submitting the payment  details
            string sql = @"INSERT INTO payment ([datePayed], [total])
                            VALUES (@datePayed, @total)
                            SELECT SCOPE_IDENTITY()";
           
            int iPaymentID;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("datePayed", PurchaseTime));
                    command.Parameters.Add(new SqlParameter("total", dTotalPrice));
                    con.Open();
                    iPaymentID = Convert.ToInt32((object)command.ExecuteScalar());

                }
            }
            //submitting the address details
            int iAddressID;
            sql = @"INSERT INTO shippingAddress ([streetNumber], [streetName], [city], [AddressState])
                            VALUES (@streetNumber, @streetName, @city, @AddressState)
                            SELECT SCOPE_IDENTITY()";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("streetNumber", userAddress.StreetNumber));
                    command.Parameters.Add(new SqlParameter("streetName", userAddress.StreetName));
                    command.Parameters.Add(new SqlParameter("city", userAddress.City));
                    command.Parameters.Add(new SqlParameter("AddressState", userAddress.State));
                    con.Open();
                    iAddressID = Convert.ToInt32((object)command.ExecuteScalar());

                }
            }

            //submitting the order details
            int iOrderID;
                sql = @"INSERT INTO orders ([userID], [paymentID], [postageOptionID], [orderStatus], [GST], [subTotal],[dateOrdered], [shippingAddressID] )
                            VALUES (@userID, @paymentID, @postageOptionID, @orderStatus, @GST, @subTotal,@dateOrdered, @shippingAddressID )
                            SELECT SCOPE_IDENTITY()";
            //should be in BL but not going to mess with this.
            int iGST = 10;
            string orderStatus = "Pending";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("userID", userID));
                    command.Parameters.Add(new SqlParameter("paymentID", iPaymentID));
                    command.Parameters.Add(new SqlParameter("postageOptionID", ipostageOptionID));
                    command.Parameters.Add(new SqlParameter("orderStatus", orderStatus));
                    command.Parameters.Add(new SqlParameter("GST", iGST));
                    command.Parameters.Add(new SqlParameter("subTotal", dTotalPrice));
                    command.Parameters.Add(new SqlParameter("dateOrdered", PurchaseTime));
                    command.Parameters.Add(new SqlParameter("shippingAddressID", 1));
                    con.Open();
                    iOrderID = Convert.ToInt32((object)command.ExecuteScalar());

                }
            }
            //submitting the items from the Order
            sql = @"INSERT INTO orderItem ([orderID], [itemID], [quantity]) VALUES";
           int i = 0;

            //Creating a Value input of all items
           foreach (CartItem item in Cart)
           {
               sql = sql + "(@orderID" + i.ToString() + ", @itemID" + i.ToString() + ", @quantity" + i.ToString() +")";
               if (Cart.Count == 1 || Cart.IndexOf(item) == Cart.Count - 1)
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
                    int j = 0;
                    foreach (CartItem item in Cart)
                    {
                        command.CommandText = sql;
                        command.Parameters.AddWithValue("orderID" + j.ToString(), iOrderID);
                        command.Parameters.AddWithValue("itemID" + j.ToString(), item.Id);
                        command.Parameters.AddWithValue("quantity" + j.ToString(), item.Quantity);
                        j++;
                    }
                    command.ExecuteNonQuery();
                }
            }
            return iOrderID;
        }
        //
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Address> GetPostCodes() 
        {
            List<Address> Postcodes = new List<Address>();
            string sql = @"SELECT *
                        FROM[dbo].[postCode]";


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Address newPostCode = CreatePostcode(reader);
                        Postcodes.Add(newPostCode);
                    }
                }
            }
            return Postcodes;
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddPostCode(string City, string State, int postCode)
        {
            string sql = @"INSERT INTO postCode ([city], [addressState], [postCode] )
                            VALUES (@city, @addressState, @postCode)";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("city", City));
                    command.Parameters.Add(new SqlParameter("addressState", State));
                    command.Parameters.Add(new SqlParameter("postCode", postCode));
                    con.Open();
                    command.ExecuteNonQuery();

                }
            }

        }

        private static Address CreatePostcode(SqlDataReader reader)
        {
            Address postcode = new Address();
            postcode.State = (string)reader["city"];
            postcode.City = (string)reader["addressState"];
            postcode.postCode = (int)reader["postCode"];

            return postcode;
        }
    }
}