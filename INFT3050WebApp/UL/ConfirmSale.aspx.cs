using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL
{
    public partial class ConfirmSale : System.Web.UI.Page
    {
        // Sale confirmation message format
        const string CONFIRM_SALE_FORMAT = "Thank you for shopping at the Used Book Store {0}. Your order confirmation has been sent to {1}. You will be notified once your order has been shipped.";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/ConfirmSale.aspx";
                Response.Redirect(url);
            }

            // Use the customers name stored in session data to display the confirmation message
            UserSession query = (UserSession)Session[UserSession.SESSION_KEY];
            if (query != null)
            {
                try
                {
                    User currentUser = new User(query.SessionId);
                    confirmSaleMessageLabel.Text = String.Format(CONFIRM_SALE_FORMAT, currentUser.FirstName, currentUser.Email);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
    }
}