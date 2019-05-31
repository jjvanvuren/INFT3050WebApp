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

        // If the cancel button is clicked go back to Checkout
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
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

            }
            catch (Exception exc)
            {
                Server.Transfer("~/UL/DefaultError.aspx?handler=Cart.aspx", true);
            }
            finally
            {
                Response.Redirect("~/UL/Cart.aspx");
            }
        }
        protected void gridCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // If delete button was selected change status to inactive
            if (e.CommandName == "cmdUpdate")
            {
                try
                {
                    string comString = e.CommandArgument.ToString();

                    if (!string.IsNullOrEmpty(comString) && int.TryParse(comString, out int iID))
                    {
                            BL.CartSession sessionInstance = (BL.CartSession)Session["cartSession"];
                            sessionInstance.RemoveItem(iID);
                    }


                }
                catch (Exception exc)
                {
                    Server.Transfer("~/UL/DefaultError.aspx?handler=Cart.aspx", true);
                }
                finally
                {
                    Response.Redirect("~/UL/Cart.aspx");
                }

            }
        }

        protected void gridCart_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdUpdate")
            {
                string comString = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(comString) && int.TryParse(comString, out int iID))
                {
                    BL.CartSession sessionInstance = (BL.CartSession)Session["cartSession"];
                    sessionInstance.RemoveItem(iID);
                }
            }

        }
    }
}