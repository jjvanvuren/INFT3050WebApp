using System;
using System.Collections.Generic;
using System.Configuration;
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
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Checkout.aspx";
                Response.Redirect(url);
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            BL.Address shippingAddress = new BL.Address();
            //street Number
            if (tbxStreetNumberShip == null)
            {
                shippingAddress.StreetNumber = tbxStreetNumber.Text.Trim();
            }
            else
            {
                shippingAddress.StreetNumber = tbxStreetNumberShip.Text.Trim();
            }

            //street Name
            if (tbxStreetNameShip == null)
            {
                shippingAddress.StreetName = tbxStreetName.Text.Trim();
            }
            else
            {
                shippingAddress.StreetName = tbxStreetNameShip.Text.Trim();
            }
            //Street City
            if ( tbxCityShip   == null)
            {
                shippingAddress.City = tbxCity.Text.Trim();
            }
            else
            {
                shippingAddress.City = tbxCityShip.Text.Trim();
            }

            //Street City
            try
            {
                if (tbxPostCodeShip == null)
                {
                    int.TryParse(tbxPostCode.Text.Trim(), out int PostCode);
                    shippingAddress.postCode = PostCode;
                }
                else
                {
                    int.TryParse(tbxPostCodeShip.Text.Trim(), out int PostCode);
                    shippingAddress.postCode = PostCode;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            //Address State
            if (ddlStateShip.SelectedIndex == 0)
            {
                shippingAddress.State = ddlState.SelectedItem.Text;
            }
            else
            {
                shippingAddress.State = ddlStateShip.SelectedItem.Text;
            }

           String shippingType = ddlShippingMethod.SelectedItem.Text;


            //this should receive a payment valid
            if (IsValid)
            {
                BL.CartSession sessionInstanceCart = (BL.CartSession)Session["cartSession"];
                BL.UserSession sessionInstanceUser = (BL.UserSession)Session["userSession"];

                sessionInstanceCart.submitCart(sessionInstanceUser.SessionId, shippingAddress, shippingType)
                ;
                Response.Redirect("~/UL/CardPayment.aspx");
            }
            
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Cart.aspx");
        }
    }
}