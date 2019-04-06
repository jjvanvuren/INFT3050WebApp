using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "Login" link
            Master.LoginLinkEnabled = false;
            Master.LoginLinkVisible = false;

            // Show and enable the "My Account" link
            Master.AccountLinkEnabled = true;
            Master.AccountLinkVisible = true;

            // Show and enable the "Logout" link
            Master.LogoutLinkEnabled = true;
            Master.LogoutLinkVisible = true;

            // Hide and disable the "Register" link
            Master.RegisterLinkEnabled = false;
            Master.RegisterLinkVisible = false;
        }
    }
}