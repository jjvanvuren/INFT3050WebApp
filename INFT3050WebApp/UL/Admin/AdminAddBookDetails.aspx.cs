using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

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
            catch(InvalidCastException)
            {
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
            catch(Exception)
            {
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


            AddBookSession newBook = new AddBookSession(newPrice, newStockQuantity, newShortDescription, newLongDescription, newImagePath, newThumbnailPath, newIsbn,
             newDatePublished, newTitle, newSecondaryTitle, newPublisher, newIsBestSeller);
            Session["addBookSession"] = newBook;

            Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");
        }
    }
}