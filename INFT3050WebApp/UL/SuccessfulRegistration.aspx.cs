using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class SuccessfulRegistration : System.Web.UI.Page
    {
        const string THANKS_FORMAT = "Thank you for registering with us {0}, please login using the link located in the top right of this page.";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "My Account" link
            Master.AccountLinkEnabled = false;
            Master.AccountLinkVisible = false;

            // Hide and disable the "Logout" link
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;

            CustomerSession query = (CustomerSession)Session[CustomerSession.SESSION_KEY];
            if (query != null)
            {
                thanksMessageLabel.Text = String.Format(THANKS_FORMAT, query.Name);
            }
        }
    }
}