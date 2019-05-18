using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class Order
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public int purchaseId { get; set; }
        public string orderStatus { get; set; }
        public int GST { get; set; }
        public double Total { get; set; }
        public String dateOrdered { get; set; }
    }
}