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

        const string THANKS_FORMAT = "Thank you for registering with us {0}.";

        protected void Page_Load(object sender, EventArgs e)
        {

            CustomerSession query = (CustomerSession)Session[CustomerSession.SESSION_KEY];
            if (query != null)
            {
                thanksMessageLabel.Text = String.Format(THANKS_FORMAT, query.Name);
            }
        }
    }
}