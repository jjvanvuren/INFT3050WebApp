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
    public partial class AdminAddBookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminAddBookDetails.aspx";
                Response.Redirect(url);
            }

        }

        protected void btnBookDetails_Click(object sender, EventArgs e)
        {
            double newPrice = 0;
            int newStockQuantity =0;
            DateTime newDatePublished = new DateTime(2019, 1, 1);

            try
            {
                 newPrice = Convert.ToDouble(tbxPrice.Text);
            }
            catch(InvalidCastException)
            {
            }
            try
            {
                newStockQuantity = Convert.ToInt32(tbxStockonHand.Text);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            String newShortDescription = tbxShortDescription.Text.Trim();
            String newLongDescription = tbxLongDescription.Text.Trim();
            String newImagePath = tbxImagePath.Text.Trim();
            String newThumbnailPath = tbxThumbnailPath.Text.Trim();
            String newIsbn = tbxISBN.Text.Trim();
            try
            {
                newDatePublished = Convert.ToDateTime(tbxDatePublished.Text.Trim());
            }
            catch (Exception exc)
            {
                throw exc;
            }
            String newTitle = tbxTitle.Text.Trim();
            String newSecondaryTitle = tbxSecondaryTitle.Text.Trim();
            String newPublisher = tbxPublisher.Text.Trim();
            Boolean newIsBestSeller;
            if (ddlIsBestSeller.SelectedIndex == 0)
            {
                newIsBestSeller = false;
            }
            else
            {
                newIsBestSeller = true;
            }

            try {
            AddBookSession newBook = new AddBookSession(newPrice, newStockQuantity, newShortDescription, newLongDescription, newImagePath, newThumbnailPath, newIsbn,
             newDatePublished, newTitle, newSecondaryTitle, newPublisher, newIsBestSeller);
            Session["addBookSession"] = newBook;

            Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}