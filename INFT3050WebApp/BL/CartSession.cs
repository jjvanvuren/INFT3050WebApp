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

        public void submitCart(int userID, Address userAddress, String postageOption)
        {
            DAL.OrderDataAccess connect = new DAL.OrderDataAccess();
            DAL.PostageOptionDataAccess postageConnect = new DAL.PostageOptionDataAccess();
            int postageOptionID=0;
                postageConnect.GetPostageOptions();
            DateTime currentDate = DateTime.Now;
            connect.submitCart(userID, userAddress, postageOptionID, Cart, totalPrice, currentDate);
        }

    }
}