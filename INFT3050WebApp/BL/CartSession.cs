using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class CartSession : UserCart
    {
        public const string SESSION_KEY = "cartSession";

        public CartSession()
        {
            Cart = new List<CartItem>();
        }

        public int submitCart(int userID, Address userAddress, int postageOption)
        {
            DAL.OrderDataAccess connect = new DAL.OrderDataAccess();
            DAL.PostageOptionDataAccess postageConnect = new DAL.PostageOptionDataAccess();
            userAddress.CheckPostCode();
            DateTime currentDate = DateTime.Now;
            int OrderID = connect.submitCart(userID, userAddress, postageOption, Cart, totalPrice, currentDate);
            return OrderID;
        }

    }
}