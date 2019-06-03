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
         //Handles the submission of the cart to the Databasse
        public int submitCart(int userID, Address userAddress, int postageOption)
        {
            double subtotalPrice = totalPrice;
            DAL.OrderDataAccess connect = new DAL.OrderDataAccess();
            //adding postage option to te total cost.
            DAL.PostageOptionDataAccess postageConnect = new DAL.PostageOptionDataAccess();
            userAddress.CheckPostCode();
            totalPrice += postageConnect.GetPostageOption(postageOption).Price;
            //get time of when Payed
            DateTime currentDate = DateTime.Now;
            int OrderID = connect.submitCart(userID, userAddress, postageOption, Cart, totalPrice,subtotalPrice, currentDate);
            return OrderID;
        }

    }
}