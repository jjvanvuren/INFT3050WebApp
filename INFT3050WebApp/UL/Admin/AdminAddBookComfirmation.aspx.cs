using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using System.Configuration;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminAddBookComfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }
            //Stop the user trying to submit the same book over and over.
            if (Session["addBookSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }                //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminAddBookComfirmation.aspx";
                Response.Redirect(url);
            }

            //Displays the book session
            try { 
                AddBookSession displayBook = (AddBookSession)Session["addBookSession"];
                lblNewTitle.Text = displayBook.Title;
                lblNewSecondTitle.Text = displayBook.SecondaryTitle;
                lblNewShortDescription.Text = displayBook.ShortDescription;
                lblNewLongDescription.Text = displayBook.LongDescription;
                lblNewISBN.Text = displayBook.Isbn;
                lblNewPublisher.Text = displayBook.Publisher;
                lblNewDatePublished.Text = displayBook.DatePublished.ToString();
                lblNewIsBestSeller.Text = displayBook.IsBestSeller.ToString();
                lblNewImagePath.Text = displayBook.ImagePath;
                lblNewThumbnailPath.Text = displayBook.ThumbnailPath;
                lblNewPrice.Text = displayBook.Price.ToString();
                lblNewStockonHand.Text = displayBook.StockQuantity.ToString();
                GridAuthors.DataSource = displayBook.addedAuthors();
                GridAuthors.DataBind();
                GridCategories.DataSource = displayBook.addedCategories();
                GridCategories.DataBind();
            }
            catch (Exception exc)
            {
                throw exc;
            }


        }
        protected void btnSubmitBook_Click(object sender, EventArgs e)
        {//submits the book to the BL layer
            try { 
                BL.AddBookSession connect = (BL.AddBookSession)Session["addBookSession"];
                connect.submitBook();
                //Removes all variables from session
                connect = new BL.AddBookSession();
                Session["addBookSession"] = connect;
                //assign the session to null to stop the back button
                Session["addBookSession"] = null;
                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}