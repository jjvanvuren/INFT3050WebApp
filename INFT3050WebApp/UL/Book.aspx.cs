using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL
{
    public partial class Book : System.Web.UI.Page
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
            // Get ID and try parse
            var idString = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
            {

                if (!IsPostBack)
                {
                    try
                    {
                        BL.Book book = new BL.Book(id);
                        if (book != null)
                        {
                            // Use data for page elements
                            lblTitle.Text = book.Title;
                            imgBook.ImageUrl = book.ImagePath;
                            lblDescription.Text = book.LongDescription;
                            lblPrice.Text = "Price: $" + book.Price.ToString();
                            lblAuthor.Text = book.Author.FirstName + " " + book.Author.LastName;
                            lblQuantity.Text = "In Stock: " + book.StockQuantity.ToString();
                            lblPublisher.Text = "Published: " + book.Publisher;
                            lblDatePublished.Text = book.DatePublished.ToShortDateString();
                        }
                    }
                    catch (Exception exception)
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

                        Server.Transfer("DefaultError.aspx", true);
                    }
                }
            }
        }
    }
}