using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "My Account" link
            Master.AccountLinkEnabled = false;
            Master.AccountLinkVisible = false;

            // Hide and disable the "Logout" link
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;

            if (!IsPostBack)
            {
                var db = new DAL.DummyDB();
                var books = db.GetBooks();

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
        }
    }
}