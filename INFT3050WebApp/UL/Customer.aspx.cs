﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using Microsoft.AspNet.FriendlyUrls;

namespace INFT3050WebApp
{
    public partial class Customer : System.Web.UI.Page
    {
        const string WELCOME_FORMAT = "Welcome {0}!";

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check if user is logged in to use correct master page
            if (Session["userSession"] != null)
            {
                Page.MasterPageFile = "~/UL/Customer.Master";
            }
            else
            {
                Page.MasterPageFile = "~/UL/Site.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Display a custom welcome message to the customer
            UserSession query = (UserSession)Session[UserSession.SESSION_KEY];
            if (query != null)
            {
                try
                {
                    User currentUser = new User(query.SessionId);

                    customerWelcome.Text = String.Format(WELCOME_FORMAT, currentUser.FirstName);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }

            if (!IsPostBack)
            {
                Book dbBook = new Book();

                List<Book> books = new List<Book>();

                try
                {
                    books = dbBook.GetAllBooks();

                    // Create list of best sellers and display them
                    List<Book> bestSellers = new List<Book>();

                    foreach (Book book in books)
                    {
                        if (book.IsBestSeller)
                        {
                            bestSellers.Add(book);
                        }
                    }

                    ImageRepeater.DataSource = bestSellers;
                    ImageRepeater.DataBind();
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }

        protected void imgBestSeller_Command(object sender, CommandEventArgs e)
        {
            // When a book's image is clicked redirect to the book's details page

            string idString = e.CommandArgument.ToString();

            var url = FriendlyUrl.Href("~/UL/Book", idString);

            Response.Redirect(url);
        }
    }
}