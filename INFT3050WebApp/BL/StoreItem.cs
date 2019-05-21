using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class StoreItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }

        public StoreItem() { }

        public StoreItem(int iItemID)
        {
            // Set up access to database
            IBookDataAccess db = new BookDataAccess();

            // get book from db using GetBookById method
            Book book = db.GetBookById(iItemID);

            this.Id = book.Id;
            this.Price = book.Price;
            this.StockQuantity = book.StockQuantity;
            this.ShortDescription = book.ShortDescription;
            this.LongDescription = book.LongDescription;
            this.ImagePath = book.ImagePath;
            this.ThumbnailPath = book.ThumbnailPath;
        }
    }
}