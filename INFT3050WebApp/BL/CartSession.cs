using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class CartSession
    {
        public const string SESSION_KEY = "cartSession";
        public UserCart Cart { get; set; }

        public CartSession() { }
    }
}