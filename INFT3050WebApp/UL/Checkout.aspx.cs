using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class Checkout : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check if user is logged in to use correct master page
            if (Session["customerSession"] != null)
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

        }

        protected void radSameAddress_CheckedChanged(object sender, EventArgs e)
        {
            tbxAddress1Ship.Enabled = false;
            tbxAddress2Ship.Enabled = false;
            tbxPostCodeShip.Enabled = false;
            tbxSuburbShip.Enabled = false;
            tbxStateShip.Enabled = false;
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("~/UL/ConfirmSale.aspx");
            }
            
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Cart.aspx");
        }
    }
}