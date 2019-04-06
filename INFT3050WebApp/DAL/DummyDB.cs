using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    public class DummyDB
    {
        // Used for Long Descriptions
        const string Lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, " +
            "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu " +
            "fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        // Used for Short Descriptions
        const string ShortLorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        private BL.Book[] books;
        private BL.Author[] authors;
        private BL.Category[] categories;

        // Default Constructor: Populates DummyDB with Dummy Data
        public DummyDB()
        {
            // Populate Categories
            int id = 0;
            categories = new BL.Category[]
            {
                CreateDummyCategory(id++, "History"),
                CreateDummyCategory(id++, "Fantasy"),
                CreateDummyCategory(id++, "Sci-Fi"),
                CreateDummyCategory(id++, "Horror"),
                CreateDummyCategory(id++, "Crime"),
                CreateDummyCategory(id++, "Self-Help"),
                CreateDummyCategory(id++, "Art"),
                CreateDummyCategory(id++, "Technology")
            };

            //Populate Best Seller Authors
            id = 0;
            authors = new BL.Author[]
            {
                CreateDummyAuthor(id++, "J L", "Pickering")
            };

            //Populate Best Seller Books
            id = 0;
            books = new BL.Book[]
            {
                CreateDummyBook(id++, 45.92, 20, "/UL/Images/9780813056173.jpg", "/UL/Images/9780813056173_thumb.jpg", "9780813056173", new DateTime (2019,04,30), "Picturing Apollo 11", "", authors[id-1], categories[id-1], "Univ Pr of Florida")
            };

        }

        // Create Book: used to create dummy Book objects
        private BL.Book CreateDummyBook(int id, double price, int quantity, string image, string thumbImage, string isbn, DateTime datePublished,
            string title, string secondTitle, BL.Author author, BL.Category category, string publisher)
        {
            BL.Book book = new BL.Book()
            {
                Id = id,
                Price = price,
                StockQuantity = quantity,
                ShortDescription = ShortLorem,
                LongDescription = Lorem,
                ImagePath = image,
                ThumbnailPath = thumbImage,
                Isbn = isbn,
                DatePublished = datePublished,
                Title = title,
                SecondaryTitle = secondTitle,
                Author = author,
                Category = category,
                Publisher = publisher,
                IsBestSeller = true
            };

            return book;
        }

        // Create Author:
        private BL.Author CreateDummyAuthor(int id, string firstName, string lastName)
        {
            BL.Author author = new BL.Author()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            return author;
        }

        //Create Category:
        private BL.Category CreateDummyCategory(int id, string name)
        {
            BL.Category category = new BL.Category()
            {
                Id = id,
                Name = name
            };

            return category;
        }

        // get book list
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.Book[] GetBooks()
        {
            return books;
        }

        // get Best Sellers
        //[DataObjectMethod(DataObjectMethodType.Select)]
        //public BL.Book[] GetBestBooks()
        //{

        //}

        // find book by ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.Book GetBooksById(int id)
        {
            return Array.Find(books, b => { return b.Id == id; });
        }
    }
}