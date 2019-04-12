using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class Logout : System.Web.UI.Page
    {

        // Logout message format
        const string LOGOUT_FORMAT = "Thank you for shopping with us {0}.";

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
            // Use the customers name stored in session data to display the logout message
            CustomerSession query = (CustomerSession)Session[CustomerSession.SESSION_KEY];
            if (query != null)
            {
                lblLogoutMessage.Text = String.Format(LOGOUT_FORMAT, query.Name);
            }

            // Clear all session data once user has logged out
            Session.Clear();
        }
    }
}