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

    }
}