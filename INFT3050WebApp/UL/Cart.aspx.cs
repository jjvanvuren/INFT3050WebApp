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

        protected void ItemManagment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void ItemManagment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}