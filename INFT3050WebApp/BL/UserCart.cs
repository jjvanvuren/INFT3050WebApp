using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class UserCart
    {
        public List<CartItem> Cart { get; set; }
        public double totalPrice;
        public UserCart () { }

        public UserCart (CartItem cartItem)
        {
            this.AddItem(cartItem);
        }

        // Add an item to cart
        public void AddItem(CartItem cartItem)
        {
            bool bDuplicate = false;

            foreach (CartItem item in Cart)
            {
                if (item.Id == cartItem.Id)
                {
                    item.Quantity++;
                    bDuplicate = true;

                }
            }
            
            if (!bDuplicate)
            {
                this.Cart.Add(cartItem);
            }
            SetCartPrice();
        }

        // Remove an item from cart
        public void RemoveItem(CartItem cartItem)
        {
            this.Cart.Remove(cartItem);
            SetCartPrice();
        }


        //Methord to get total Price of Items in cart
        public void SetCartPrice()
        {
            totalPrice = 0;
            foreach (CartItem item in Cart)
            {   
                totalPrice = +item.Price*item.Quantity;
            }
        }

        //Methord of getting the cart
        public List<CartItem> GetCart()
        {
            if (Cart == null)
            {
                Cart = new List<CartItem>();
            }
            return Cart;
        }
    }
}