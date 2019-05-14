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
        private BL.User[] user;
        private BL.PostageOption[] postageOption;
        private BL.Order[] orders;

        // Default Constructor: Populates DummyDB with Dummy Data
        public DummyDB()
        {
            // Populate Categories
            int id = 0;
            categories = new BL.Category[]
            {
                CreateDummyCategory(id++, "History"),
                CreateDummyCategory(id++, "Thriller"),
                CreateDummyCategory(id++, "Sci-Fi"),
                CreateDummyCategory(id++, "Horror"),
                CreateDummyCategory(id++, "Crime"),
                CreateDummyCategory(id++, "Fantasy"),
                CreateDummyCategory(id++, "Art"),
                CreateDummyCategory(id++, "Technology")
            };

            //Populate Best Seller Authors
            id = 0;
            authors = new BL.Author[]
            {
                CreateDummyAuthor(id++, "J L", "Pickering"),
                CreateDummyAuthor(id++, "K.L.", "Slater"),
                CreateDummyAuthor(id++, "Mark", "Lawrence"),
                CreateDummyAuthor(id++, "Ruth", "Hogan"),
                CreateDummyAuthor(id++, "Harlan", "Coben"),
                CreateDummyAuthor(id++, "Metropolitan Museum of Art New York", ""),
                CreateDummyAuthor(id++, "Ashlee", "Vance")

            };

            //Populate Books
            id = 0;
            books = new BL.Book[]
            {
                // Add Books
                CreateDummyBook(id++, 45.92, 20, "/UL/Images/9780813056173.jpg", "/UL/Images/9780813056173_thumb.jpg", "9780813056173", new DateTime (2019,04,30), "Picturing Apollo 11", "", authors[id-1], categories[id-1], "Univ Pr of Florida", true),
                CreateDummyBook(id++, 16.49, 20, "/UL/Images/9781786812445.jpg", "/UL/Images/9781786812445_thumb.jpg", "9781786812445", new DateTime (2017,10,04), "The Mistake", "", authors[id-1], categories[id-1], "Bookouture", true),
                CreateDummyBook(id++, 22.99, 20, "/UL/Images/9781503903265.jpg", "/UL/Images/9781503903265_thumb.jpg", "9781503903265", new DateTime (2019,05,01), "One Word Kill", "", authors[id-1], categories[id-1], "47 North", true),
                CreateDummyBook(id++, 16.81, 20, "/UL/Images/9781473635487.jpg", "/UL/Images/9781473635487_thumb.jpg", "9781473635487", new DateTime (2017,08,10), "The Keeper of Lost Things", "", authors[id-1], categories[id-1], "Hodder & Stoughton General Division", true),
                CreateDummyBook(id++, 16.11, 20, "/UL/Images/9781784751173.jpg", "/UL/Images/9781784751173_thumb.jpg", "9781784751173", new DateTime (2018,08,06), "Run Away", "", authors[id-1], categories[id-1], "ARROW LTD", true),
                CreateDummyBook(id++, 19.99, 20, "/UL/Images/9780008152406.jpg", "/UL/Images/9780008152406_thumb.jpg", "9780008152406", new DateTime (2019,03,18), "Holy Sister", "", authors[2], categories[id-1], "Voyager - GB", true),
                CreateDummyBook(id++, 74.62, 20, "/UL/Images/9780847846597.jpg", "/UL/Images/9780847846597_thumb.jpg", "9780847846597", new DateTime (2016,10,01), "Masterpiece Paintings", "", authors[id-2], categories[id-1], "Rizzoli", true),
                CreateDummyBook(id++, 23.36, 20, "/UL/Images/9780753555644.jpg", "/UL/Images/9780753555644_thumb.jpg", "9780753555644", new DateTime (2016,03,10), "Elon Musk", "", authors[id-2], categories[id-1], "Ebury Publishing", true)
            };

            //Populate users
            id = 0;
            user = new BL.User[]
            {
                // Add user
               CreateDummyUser(id++, "joe@example.com", "password", "Joe", "", 0, 1),
               CreateDummyUser(id++, "james@example.com", "password", "James", "Smith", 0, 0),
               CreateDummyUser(id++, "sara@example.com", "password", "Sara", "Headges", 0, 1),
               CreateDummyUser(id++, "alex@usedbooksales.com.au", "password", "Alex", "Budwill", 1, 1),
               CreateDummyUser(id++, "patrick@usedbooksales.com.au", "password", "Patrick", "Foley", 1, 1),
               CreateDummyUser(id++, "derrick@example.com", "password", "Derrick", "Hardy", 0, 1),
               CreateDummyUser(id++, "soli@example.com", "password", "Soli", "Soliman", 0, 0),
               CreateDummyUser(id++, "chelsea@example.com", "password", "chelsea", "Gordon", 0, 0),
               CreateDummyUser(id++, "karl@usedbooksales.com.au", "password", "Karl", "Foley", 1, 1),
               CreateDummyUser(id++, "jacques@usedbooksales.com.au", "password", "Jacques", "Janse van Vuren", 1, 1),
               CreateDummyUser(id++, "francois@usedbooksales.com.au", "password", "Francois", "Janse van Vuren", 1, 1)
            };

            //Populate Postage Options
            id = 0;
            postageOption = new BL.PostageOption[]
            {
                CreatePostageOption(id++, "Pick Up", 0),
                CreatePostageOption(id++, "AusPost", 5.99),
                CreatePostageOption(id++, "AusPost Express", 9.99),
                CreatePostageOption(id++, "Startrack", 3.99),
                CreatePostageOption(id++, "Startrack Express", 7.99)
            };

            // Populate Orders
            id = 0;
            orders = new BL.Order[]
            {
                CreateDummyOrders(id++,1,id++,"shipped",10,4.99, "4/5/2019"),
                CreateDummyOrders(id++,1,id++,"WaitingShip",10,14.99, "3/7/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,4.99, "4/7/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,20.99, "4/12/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,31.99, "23/9/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,2.99, "28/5/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,5.99, "22/9/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,6.99, "2/10/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,8.99, "3/3/2019"),
                CreateDummyOrders(id++,1,id++,"shipped",10,7.99, "1/2/2019")
            };

        }

    // Create Book: used to create dummy Book objects
    private BL.Book CreateDummyBook(int id, double price, int quantity, string image, string thumbImage, string isbn, DateTime datePublished,
            string title, string secondTitle, BL.Author author, BL.Category category, string publisher, bool isBestSell)
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
                IsBestSeller = isBestSell
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

        //Create Category: Create a dummy category
        private BL.Category CreateDummyCategory(int id, string name)
        {
            BL.Category category = new BL.Category()
            {
                Id = id,
                Name = name
            };

            return category;
        }

        // Create User: Used to create a dummy user
        private BL.User CreateDummyUser(int id, string email, string password, string firstName, string lastName, int isadmin, int isactive)
        {
            BL.User user = new BL.User()
            {
                Id = id,
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                IsAdmin = isadmin,
                IsActive = isactive
            };

            return user;
        }

        // Create Order: used to create a dummy order
        private BL.Order CreateDummyOrders(int OrderId, int UserId, int PurchaseId, string OrderStatus, int gst, double total, String DateOrdered)
        {
            BL.Order order = new BL.Order()
            {
                orderId = OrderId,
                userId = UserId,
                purchaseId = PurchaseId,
                orderStatus = OrderStatus,
                GST = gst,
                Total = total,
                dateOrdered = DateOrdered
            };

            return order;
        }

        // Create PostageOption: Used to create a dummy postage option
        private BL.PostageOption CreatePostageOption(int id, string name, double price)
        {
            BL.PostageOption postageOption = new BL.PostageOption()
            {
                Id = id,
                Name = name,
                Price = price
            };
            return postageOption;
        }

        // get book list
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.Book[] GetBooks()
        {
            return books;
        }

        // find book by ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.Book GetBookById(int id)
        {
            return Array.Find(books, b => { return b.Id == id; });
        }

        // get user list
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.User[] GetUsers()
        {
            return user;
        }


        // get postage option list
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.PostageOption[] GetPostageOptions()
        {
            return postageOption;
        }

        // find orders
        [DataObjectMethod(DataObjectMethodType.Select)]
        public BL.Order[] GetOrders()
        {
            return orders;
        }

    }
}