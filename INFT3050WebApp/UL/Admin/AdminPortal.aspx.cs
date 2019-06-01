using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.BackEnd
{
    //On PreInit check session data to see if logged in if not send to AdminLogin.axpc
    public partial class BackEndEmployeePortal : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminPortal.aspx";
                Response.Redirect(url);
            }
        }

        //Button to add a new book to database: No functionality yet
        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Admin/AdminAddBookDetails.aspx");
        }

        protected void ItemManagment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = ItemManagment.Rows[e.RowIndex];
                string sID = row.Cells[0].Text;
                string updatedTitle = ((TextBox)row.Cells[2].FindControl("txtGridTitle")).Text;
                string updatedPrice = ((TextBox)row.Cells[3].FindControl("txtGridPrice")).Text;
                string updateStockOnHand = ((TextBox)row.Cells[4].FindControl("txtGridStockQuantity")).Text;
                string updatedImagePath = ((TextBox)row.Cells[5].FindControl("txtGridImagePath")).Text;
                string updatedThumbnail = ((TextBox)row.Cells[6].FindControl("txtGridThumbnailPath")).Text;



                if (int.TryParse(sID, out int iID) && double.TryParse(updatedPrice, out double dPrice)&& int.TryParse(updateStockOnHand, out int iStockOnHand))
                {
                    BL.Book updatedBook = new BL.Book();
                    updatedBook.Id = iID;
                    updatedBook.Title = updatedTitle;
                    updatedBook.Price = dPrice;
                    updatedBook.StockQuantity = iStockOnHand;
                    updatedBook.ImagePath = updatedImagePath;
                    updatedBook.ThumbnailPath = updatedThumbnail;
                    int rowsAffected = updatedBook.UpdateBookbyID(updatedBook);
                }
            }
            catch (Exception exc)
            {
                Server.Transfer("~/UL/DefaultError.aspx?handler=AdminPortal.aspx", true);
            }
            finally
            {
                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }
        }

        protected void ItemManagment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = ItemManagment.Rows[e.RowIndex];
                string sID = row.Cells[0].Text;
                string sIsActive = row.Cells[1].Text;
                if (int.TryParse(sID, out int iID)&& Boolean.TryParse(sIsActive, out Boolean boolIsActive))
                {
                    boolIsActive = !boolIsActive;
                    BL.Book DeleteBook = new BL.Book();

                    DeleteBook.DeleteBookbyID(iID, boolIsActive);
                }

            }
            catch (Exception)
            {
                Server.Transfer("~/UL/DefaultError.aspx?handler=AdminPortal.aspx", true);
            }
            finally
            {
                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }
        }
    }
}