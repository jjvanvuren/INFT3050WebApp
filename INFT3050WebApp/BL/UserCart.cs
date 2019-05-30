using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class UserCart
    {
        public List<CartItem> Cart { get; set; }

        // Add an item to cart
        public void AddItem(CartItem cartItem)
        {
            this.Cart.Add(cartItem);
        }

        // Remove an item from cart
        public void RemoveItem(CartItem cartItem)
        {
            this.Cart.Remove(cartItem);
        }
    }
}