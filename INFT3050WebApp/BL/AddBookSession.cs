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
        public AddBookSession() { }


        //Methord used to save book information to the session and start Lists for author and Categories
        public AddBookSession(double newPrice, int newStockQuantity, String newShortDescription, String newLongDescription, String newImagePath, String newThumbnailPath, String newIsbn,
            DateTime newDatePublished, String newTitle, String newSecondaryTitle, String newPublisher, Boolean newIsBestSeller)
        {
  

            Price = newPrice;
            StockQuantity = newStockQuantity;
            DatePublished = newDatePublished;
            IsBestSeller = newIsBestSeller;
            Authors = new List<Author>();
            Categories = new List<Category>();
            //All string types have checks around them to make sure Nulls are submitted to the data base
            if (newShortDescription != null)
            {
                ShortDescription = newShortDescription;
            } else
            {
                ShortDescription = "";
            }

            if (newLongDescription != null)
            {
                LongDescription = newLongDescription;
            }
            else
            {
                LongDescription = "";
            }

            if (newImagePath != null)
            {
                ImagePath = newImagePath;
            }
            else
            {
                ImagePath = "";
            }

            if (newThumbnailPath != null)
            {
                ThumbnailPath = newThumbnailPath;
            }
            else
            {
                ThumbnailPath = "";
            }

            if (newIsbn != null)
            {
                Isbn = newIsbn;
            }
            else
            {
                Isbn = "";
            }

            if (newTitle != null)
            {
                Title = newTitle;
            }
            else
            {
                Title = "";
            }

            if (newSecondaryTitle != null)
            {
                SecondaryTitle = newSecondaryTitle;
            }
            else
            {
                SecondaryTitle = "";
            }

            if (newPublisher != null)
            {
                Publisher = newPublisher;
            }
            else
            {
                Publisher = "";
            }
            
        }


        //Used to added authors selected to the book session
        public void AddAuthorToBook(Author newAuthor) {
            //Make sure that the list has been started
            if(Authors == null)
            {
                Authors = new List<Author>();
            }
            int intDuplicate = 0;
            foreach (Author ID in Authors) {
                if (ID.Id == newAuthor.Id)
                {
                    intDuplicate = 1;
                }
            }
            if ( intDuplicate == 0)
            {
                Authors.Add(newAuthor);
            }
        
        }


        //Used to added categories selected to the book takes a list of ints and matches those as IDs to a list of categories
        public void AddCategoryToBook(List<int> newCategories)
        {   //Make sure that the list for categories has been started
            if (Categories == null)
            {
                Categories = new List<Category>();
            }
            Category newCategory = new Category();
            //Connecting to the data base to get categories
            List<Category> ListOfCategoires = newCategory.getCategories();
            foreach (int CategoryID in newCategories)
            {
                bool categoryFound = false;
                //Stop from the same Category been added twice to the session List.
                foreach (Category cat in Categories)
                {
                    if (cat.Id == CategoryID)
                    {
                        categoryFound = true;
                    }
                }
                //Only iterating though till its found then moves onto the next one in the list
                while (categoryFound !=true)
                {
                    foreach (Category cat in ListOfCategoires)
                    {
                        if (cat.Id == CategoryID)
                        {
                            categoryFound = true;
                            Categories.Add(cat);
                        }
                    }
                }
            }

        }

        //used to create a book from the session data does not take lists for author and category
        //because those are not needed to be passed to the book data access layer, they are passed
        //to their corisponding data access layer.
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

        //Methord returns the list of added authors. 
        public List<Author> addedAuthors()
        {
            return Authors;
        }
        //Methord returns the list of added categories. 
        public List<Category> addedCategories()
        {
            return Categories;
        }


        //used to submit the book off to the Data access layers to create the book.
        public void submitBook()
        {
            
            Book newBook = this.createTempBook();
            DAL.BookDataAccess connect = new BookDataAccess();
            newBook.Id = connect.SubmitBook(newBook);
            DAL.AuthorDataAccess connectAuthor = new AuthorDataAccess();
            connectAuthor.ConnectBookAuthor(newBook.Id, Authors);
            DAL.CategoryDataAccess connectCategory = new CategoryDataAccess();
            connectCategory.ConnectBookCategory(newBook.Id, Categories); 
        }
    }
}