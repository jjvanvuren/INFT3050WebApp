using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.BackEnd
{
    public partial class BackEndLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Master.ToolsVisible = false;
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }

        // Validate email and password. If successful redirect to Customer.aspx
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Session.Clear();

                UserSession currentUserSession = new UserSession()
                {
                    Email = tbxEmail.Text,
                    Name = "Joe Smith",
                    LoggedIn = true
                };

                Session["UserSession"] = currentUserSession;

                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/UL/Admin/AdminRegister.aspx");
        }

        // Checks if customer password is correct
        // This is only temporary. Will change in next assignment
        protected void passwordCorrect(object source, ServerValidateEventArgs args)
        {
            if (tbxPassword.Text == "password")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}