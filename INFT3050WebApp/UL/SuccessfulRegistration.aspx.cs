using System;
using System.Web.UI;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class SuccessfulRegistration : System.Web.UI.Page
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

        const string THANKS_FORMAT = "Thank you for registering with us {0}.";

        protected void Page_Load(object sender, EventArgs e)
        {

            UserSession query = (UserSession)Session[UserSession.SESSION_KEY];
            if (query != null)
            {
                try
                {
                    // Show custom thank you message to customer
                    User currentUser = new User(query.SessionId);
                    thanksMessageLabel.Text = String.Format(THANKS_FORMAT, currentUser.FirstName);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
    }
}