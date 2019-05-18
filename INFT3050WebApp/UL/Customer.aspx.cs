using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp
{
    public partial class Customer : System.Web.UI.Page
    {
        const string WELCOME_FORMAT = "Welcome {0}!";

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


            CustomerSession query = (CustomerSession)Session[CustomerSession.SESSION_KEY];
            if (query != null)
            {
                // Setup access to database
                IUserDataAccess db = new UserDataAccess();

                User currentUser = db.GetUserById(query.SessionId);

                string strUserName = currentUser.FirstName;

                customerWelcome.Text = String.Format(WELCOME_FORMAT, strUserName);
            }

            if (!IsPostBack)
            {
                // Create dummy database and pull all books from database
                var db = new DAL.BookDataAccess();
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