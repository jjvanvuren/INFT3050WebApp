using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class Cart : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Check if user is logged in to use correct master page
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
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Cart.aspx";
                Response.Redirect(url);
            }
            if (Session["cartSession"] == null)
            {
                BL.CartSession cartCurrent = new BL.CartSession();
                Session["cartSession"] = cartCurrent;
            }
            BL.CartSession populateGridView = (BL.CartSession)Session["cartSession"];
            gridCart.DataSource = populateGridView.GetCart();
            gridCart.DataBind();
            lblTheTotalPrice.Text = populateGridView.totalPrice.ToString();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check if the session has expired
            if (Session["userSession"] == null)
            {
                Response.Redirect("SessionExpired.aspx");
            }

            Response.Redirect("~/UL/Checkout.aspx");
        }

        protected void gridCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string sID = gridCart.DataKeys[e.RowIndex].Value.ToString();
                if (int.TryParse(sID, out int iID))
                {
                    BL.CartSession sessionInstance = (BL.CartSession)Session["cartSession"];
                    sessionInstance.RemoveItem(iID);
                }

                Response.Redirect("~/UL/Cart.aspx");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
                //this was for updating quantity but for some reason It wount read the new number from the next box
               //Identical code to example code of cart given
        //protected void UpdateQuantity_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        updateQuantities();
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //    finally
        //    {
        //        Response.Redirect("~/UL/Cart.aspx");
        //    }
        //}

        //private void updateQuantities()
        //{
        //    try
        //    {
        //        foreach (GridViewRow gvrow in gridCart.Rows)
        //        {
        //            string sID = gridCart.DataKeys[gvrow.RowIndex].Values[0].ToString();  
        //            string updatedQuantity = ((TextBox)gridCart.Rows[gvrow.RowIndex].FindControl("txtQuantity")).Text;
        //            if (int.TryParse(sID, out int iID) &&(int.TryParse(updatedQuantity, out int iQuantity)))
        //            {
        //                BL.CartSession sessionInstance = (BL.CartSession)Session["cartSession"];
        //                sessionInstance.UpdateItem(iID, iQuantity);
        //            }

        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //}
    }
}