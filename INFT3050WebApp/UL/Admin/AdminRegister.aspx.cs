using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.BackEnd
{
    public partial class BackEndRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "Logout" link and links to other pages from master
            Master.ToolsVisible = false;
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }

        //If registration is valid, send user to AdminPortal.aspx and create a session for login.
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Used for BL Validation
            bool bValid;

            // Create a new user based on info entered
            User registeredUser = new User(tbxEmail.Text, tbxPassword.Text, tbxFirstName.Text, tbxLastName.Text, true, true);

            int iRegistered = registeredUser.CheckRegisterUser(tbxEmail.Text, tbxPassword.Text);

            if (iRegistered == 0)
            {
                lblEmailExists.Text = "Is not a valid email or is already registered";
                lblEmailExists.Visible = true;

                bValid = false;
            }
            else if (iRegistered == 1)
            {
                lblInvalidPassword.Text = "Password must meet complexity requirements";
                lblInvalidPassword.Visible = true;

                bValid = false;
            }
            else
            {
                lblEmailExists.Visible = false;
                lblInvalidPassword.Visible = false;

                bValid = true;
            }

            if (IsValid && bValid)
            {
                User currentUser = new User();

                currentUser.RegisterNewUser(registeredUser);

                User dbUser = new User(registeredUser.Email);

                // Data to be retained in session
                UserSession currentUserSession = new UserSession
                {
                    SessionId = dbUser.Id
                };

                Session["userSession"] = currentUserSession;

                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }
        }

        //On click handler for cancel button - Sends to AdminLogin.aspx
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Admin/AdminLogin.aspx");
        }
    }
}