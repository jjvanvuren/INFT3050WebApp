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
            String newShortDescription = tbxShortDescription.Text;
            String newLongDescription = tbxLongDescription.Text;
            String newImagePath = tbxImagePath.Text;
            String newThumbnailPath = tbxThumbnailPath.Text;
            String newIsbn = tbxISBN.Text;
            try
            {
                newDatePublished = Convert.ToDateTime(tbxDatePublished.Text);
            }
            catch(Exception)
            {
            }
            String newTitle = tbxTitle.Text;
            String newSecondaryTitle = tbxSecondaryTitle.Text;
            String newPublisher = tbxPublisher.Text;
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
            Session["userSession"] = newBook;
            Response.Redirect("~/UL/Admin/AddAuthorCategory.aspx");
        }
    }
}