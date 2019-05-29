using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using System.Web.Routing;


namespace INFT3050WebApp
{
    public partial class Default : System.Web.UI.Page
    {
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

            if (!IsPostBack)
            {
                //// Create dummy database and pull all books from database
                //var db = new DAL.BookDataAccess();
                //var books = db.GetBooks();
                Book dbBook = new Book();

                List<Book> books = new List<Book>();

                try
                {

                    books = dbBook.GetAllBooks();

                    // Create list of best sellers based on IsBestSeller property
                    List<Book> bestSellers = new List<Book>();

                    foreach (Book book in books)
                    {
                        if (book.IsBestSeller)
                        {
                            bestSellers.Add(book);
                        }
                    }
                    // Use best seller list as data source for splash page
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

                    Server.Transfer("DefaultError.aspx?handler=Default.aspx", true);

                }
            }
        }

        //private void Page_Error(object sender, EventArgs e)
        //{
        //    // Get last error from the server.
        //    Exception exc = Server.GetLastError();

        //    // Handle specific exception.
        //    if (exc is InvalidOperationException)
        //    {
        //        // Pass the error on to the error page.
        //        Server.Transfer("DefaultError.aspx?handler=Page_Error%20-%20Default.aspx", true);
        //    }
        //}

        protected void imgBestSeller_Command(object sender, CommandEventArgs e)
        {
            // When a book's image is clicked redirect to the book's details page
            Response.Redirect("Book.aspx?id=" + e.CommandArgument);
        }
    }
}