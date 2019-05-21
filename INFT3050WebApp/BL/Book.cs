using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class Book : StoreItem
    {
        public string Isbn { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string SecondaryTitle { get; set; }
        public Author Author { get; set; } 
        public Category Category { get; set; }
        public string Publisher { get; set; }
        public bool IsBestSeller { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public Book() { }

        public Book (int iItemID) : base(iItemID)
        {
            // Set up access to database
            IBookDataAccess db = new BookDataAccess();

            // get book from db using GetBookById method
            Book book = db.GetBookById(iItemID);

            this.Isbn = book.Isbn;
            this.Title = book.Title;
            this.SecondaryTitle = book.SecondaryTitle;
            this.Author = book.Author;
            this.Category = book.Category;
            this.Publisher = book.Publisher;
            this.IsBestSeller = book.IsBestSeller;
            this.AuthorId = book.AuthorId;
            this.CategoryId = book.CategoryId;
        }

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
    }
}