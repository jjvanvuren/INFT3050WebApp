using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.BL
{
    public class AddBookSession : Book
    {
        public const string SESSION_KEY = "addBookSession";
        public int SessionId { get; set; }
        public List<int> AuthorIDs { get; set; }
        public  List<int> CategoryIDs { get; set; }
        public AddBookSession() { }


        public AddBookSession(double  newPrice, int  newStockQuantity, String newShortDescription, String newLongDescription, String newImagePath, String newThumbnailPath, String newIsbn, 
            DateTime newDatePublished, String newTitle, String newSecondaryTitle, String newPublisher, Boolean newIsBestSeller)
        {

            Price = newPrice;
            StockQuantity = newStockQuantity;
            ShortDescription = newShortDescription;
            LongDescription = newLongDescription;
            ImagePath = newImagePath;
            ThumbnailPath = newThumbnailPath;
            Isbn = newIsbn;
            DatePublished = newDatePublished;
            Title = newTitle;
            SecondaryTitle = newSecondaryTitle;
            Publisher = newPublisher;
            IsBestSeller = newIsBestSeller;
        }

        public void AddAuthorID(int AuthorID) {

            if(AuthorIDs == null)
            {
                AuthorIDs = new List<int>();
            }
            int intDuplicate = 0;
            foreach (int ID in AuthorIDs) {
                if (ID == AuthorID)
                {
                    intDuplicate = 1;
                }
            }
            if ( intDuplicate == 0)
            {
                AuthorIDs.Add(AuthorID);
            }
        
        }

        public void AddCategoryIDs(List<int> CategoryID)
        {
            CategoryIDs = new List<int>(CategoryID);

        }

        public Book createTempBook()
        {
            Book bookTemp = new Book();



            bookTemp.Price = this.Price;
            bookTemp.StockQuantity = this.StockQuantity;
            bookTemp.ShortDescription = this.ShortDescription;
            bookTemp.LongDescription = this.LongDescription;
            bookTemp.ImagePath = this.ImagePath;
            bookTemp.ThumbnailPath = this.ThumbnailPath;
            bookTemp.Isbn = this.Isbn;
            bookTemp.DatePublished = this.DatePublished;
            bookTemp.Title = this.Title;
            bookTemp.SecondaryTitle = this.SecondaryTitle;
            bookTemp.Publisher = this.Publisher;
            bookTemp.IsBestSeller = this.IsBestSeller;

            return bookTemp;
        }



        //public void RemoveAuthorID(int AuthorID)
        //{
        //    AuthorIDs.RemoveAt(AuthorIDs.FindIndex(AuthorIDs.Contains(AuthorID));
        //}

    }
}