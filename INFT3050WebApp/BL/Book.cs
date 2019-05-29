using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.BL
{
    public class Book : StoreItem
    {
        public string Isbn { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string SecondaryTitle { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
        public string Publisher { get; set; }
        public bool IsBestSeller { get; set; }

        public Book()
        {
            //Set default values
            Price = 0.00;
            StockQuantity = 0;
            ShortDescription = "";
            LongDescription = "";
            ImagePath = "";
            ThumbnailPath = "";
            Isbn = "";
            Title = "";
            SecondaryTitle = "";
            Publisher = "";
            IsBestSeller = false;
        }

        public Book (int iItemID)
        {
            // Set up access to database
            IBookDataAccess db = new BookDataAccess();

            // get book from db using GetBookById method
            Book book = db.GetBookById(iItemID);

            Id = book.Id;
            Price = book.Price;
            StockQuantity = book.StockQuantity;
            ShortDescription = book.ShortDescription;
            LongDescription = book.LongDescription;
            ImagePath = book.ImagePath;
            ThumbnailPath = book.ThumbnailPath;
            Isbn = book.Isbn;
            DatePublished = book.DatePublished;
            Title = book.Title;
            SecondaryTitle = book.SecondaryTitle;
            Authors = book.Authors;
            Categories = book.Categories;
            Publisher = book.Publisher;
            IsBestSeller = book.IsBestSeller;
        }
        // Method to get all active books from database
        public List<Book> GetAllBooks()
        {
            var db = new BookDataAccess();
            var books = db.GetBooks();

            List<Book> allBooks = new List<Book>();

            foreach (Book book in books)
            {
                allBooks.Add(book);
            }

            return allBooks;
        }
        // Method to get books by their category ID
        public List<Book> GetBooksByCategory(int CategoryId)
        {
            var db = new BookDataAccess();
            var books = db.GetBooksByCategory(CategoryId);

            List<Book> allBooks = new List<Book>();

            foreach (Book book in books)
            {
                allBooks.Add(book);
            }

            return allBooks;
        }

        // Method to search books by their title
        public List<Book> SearchBooksByTitle(string searchString)
        {
            var db = new BookDataAccess();
            var books = db.SearchBooksByTitle(searchString);

            List<Book> allBooks = new List<Book>();

            foreach (Book book in books)
            {
                allBooks.Add(book);
            }

            return allBooks;
        }
    }
}