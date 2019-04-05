using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "My Account" link
            Master.AccountLinkEnabled = false;
            Master.AccountLinkVisible = false;

            // Hide and disable the "Logout" link
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("~/SuccessfulRegistration.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}