using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class CartItem:Book
    {
        public int Quantity { get; set; }

        public CartItem() { }

        public CartItem(int iId, int iQuantity)
        {
            Book book = new Book(iId);

            this.Id = book.Id;
            this.Price = book.Price;
            this.StockQuantity = book.StockQuantity;
            this.ShortDescription = book.ShortDescription;
            this.LongDescription = book.LongDescription;
            this.ImagePath = book.ImagePath;
            this.ThumbnailPath = book.ThumbnailPath;
            this.Isbn = book.Isbn;
            this.DatePublished = book.DatePublished;
            this.Title = book.Title;
            this.SecondaryTitle = book.SecondaryTitle;
            this.Authors = book.Authors;
            this.Categories = book.Categories;
            this.Publisher = book.Publisher;
            this.IsBestSeller = book.IsBestSeller;
            this.Quantity = iQuantity;
        }
    }
}