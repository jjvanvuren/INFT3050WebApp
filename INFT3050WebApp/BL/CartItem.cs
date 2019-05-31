using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public CartItem() { }

        public CartItem(int iId, int iQuantity)
        {
            this.Id = iId;
            this.Quantity = iQuantity;
        }
    }
}