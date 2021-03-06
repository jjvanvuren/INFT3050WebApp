﻿using System;
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
        public AddBookSession() {
            Authors = new List<Author>();
            Categories = new List<Category>();
        }
        //Constructor for AddBookSession with varaibles passed to it
        public AddBookSession(double newPrice, int newStockQuantity, String newShortDescription, String newLongDescription, String newImagePath, String newThumbnailPath, String newIsbn,
            DateTime newDatePublished, String newTitle, String newSecondaryTitle, String newPublisher, Boolean newIsBestSeller)
        {
  

            Price = newPrice;
            StockQuantity = newStockQuantity;
            DatePublished = newDatePublished;
            IsBestSeller = newIsBestSeller;
            Authors = new List<Author>();
            Categories = new List<Category>();
            //All string trypes have checks around them to make sure Nulls are submitted to the data base
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


        //Used to added authors selected to the book
        public void AddAuthorToBook(Author newAuthor) {

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


        //Used to added categories selected to the book
        public void AddCategoryToBook(List<int> newCategories)
        {
            Category newCategory = new Category();
            List<Category> ListOfCategoires = newCategory.getCategories();
            foreach (int CategoryID in newCategories)
            {
                bool categoryFound = false;
                //stop from adding the same category multiple times to the book
                foreach (Category alreadyAdded in Categories)
                {
                    if(CategoryID == alreadyAdded.Id)
                    {
                        categoryFound = true;
                    }
                }
                //adding the category to the book
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
        //Creating the book session for submission
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
        //Getter methord for Authors
        public List<Author> addedAuthors()
        {
            return Authors;
        }
        //Getter methord for Categories
        public List<Category> addedCategories()
        {
            return Categories;
        }
        //Submitting book to the data base
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



        //public void RemoveAuthorID(int AuthorID)
        //{
        //    AuthorIDs.RemoveAt(AuthorIDs.FindIndex(AuthorIDs.Contains(AuthorID));
        //}

    }
}