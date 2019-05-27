using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminAddBookComfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserSession"] == null)
            //{
            //    Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            //}

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
        protected void btnSubmitBook_Click(object sender, EventArgs e)
        {
            BL.AddBookSession connect = (BL.AddBookSession)Session["addBookSession"];
            connect.submitBook();

        }
    }
}