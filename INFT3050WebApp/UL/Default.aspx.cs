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
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check if user is logged in to use correct master page
            if (Session["customerSession"] != null)
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

        protected void imgBestSeller_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Book.aspx?id=" + e.CommandArgument);
        }
    }
}