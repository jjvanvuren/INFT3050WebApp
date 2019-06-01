using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class Order
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public int paymentId { get; set; }
        public int postageOptionId { get; set; }
        public string orderStatus { get; set; }
        public int GST { get; set; }
        public double Total { get; set; }
        public DateTime dateOrdered { get; set; }

        public Order() { }

        // Method to get orders by UserID
        public List<Order> GetOrdersByUserID(int Id)
        {
            var db = new OrderDataAccess();
            var orders = db.GetOrdersByUserID(Id);

            List<Order> allOrders = new List<Order>();

            foreach (Order order in orders)
            {
                allOrders.Add(order);
            }

            return allOrders;
        }
    }
}