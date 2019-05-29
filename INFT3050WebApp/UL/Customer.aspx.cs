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

            UserSession query = (UserSession)Session[UserSession.SESSION_KEY];
            if (query != null)
            {
                try
                {
                    User currentUser = new User(query.SessionId);

                    customerWelcome.Text = String.Format(WELCOME_FORMAT, currentUser.FirstName);
                }
                catch (Exception)
                {
                    //string exceptionString = "?error=" + exception.Message;

                    //if (exception.InnerException != null)
                    //{
                    //    exceptionString += "&innerex=" + exception.GetType().ToString() + "<br/>" + exception.InnerException.Message;
                    //    exceptionString += "&stacktrace=" + exception.InnerException.StackTrace;
                    //}
                    //else
                    //{
                    //    exceptionString += "&innerex=" + exception.GetType().ToString();
                    //    if (exception.StackTrace != null)
                    //    {
                    //        exceptionString += "&stacktrace=" + exception.StackTrace.ToString().TrimStart();
                    //    }
                    //}

                    //Response.Redirect("DefaultError.aspx" + exceptionString);

                    Server.Transfer("DefaultError.aspx?handler=Customer.aspx", true);
                }


            }

            if (!IsPostBack)
            {
                //// Create dummy database and pull all books from database
                //var db = new BookDataAccess();
                //var books = db.GetBooks();

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
                catch (Exception)
                {
                    //string exceptionString = "?error=" + exception.Message;

                    //if (exception.InnerException != null)
                    //{
                    //    exceptionString += "&innerex=" + exception.GetType().ToString() + "<br/>" + exception.InnerException.Message;
                    //    exceptionString += "&stacktrace=" + exception.InnerException.StackTrace;
                    //}
                    //else
                    //{
                    //    exceptionString += "&innerex=" + exception.GetType().ToString();
                    //    if (exception.StackTrace != null)
                    //    {
                    //        exceptionString += "&stacktrace=" + exception.StackTrace.ToString().TrimStart();
                    //    }
                    //}

                    //Response.Redirect("DefaultError.aspx" + exceptionString);

                    Server.Transfer("DefaultError.aspx?handler=Customer.aspx", true);
                }

            }
        }

        protected void imgBestSeller_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Book.aspx?id=" + e.CommandArgument);
        }
    }
}