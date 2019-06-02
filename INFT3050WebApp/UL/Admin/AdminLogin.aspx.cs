using System;
using System.Configuration;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.BackEnd
{
    public partial class BackEndLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminLogin.aspx";
                Response.Redirect(url);
            }

            // Hide and disable the "Logout" link and links to other pages from master
            Session.Clear();
            Master.ToolsVisible = false;
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }

        // Validate email and password. If successful redirect to Customer.aspx
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Clear();

            string strEmail = tbxEmail.Text;
            string strPassword = tbxPassword.Text;

            int iCheckUser;
            User userVerify = new User();

            // Used for BL Validation
            bool bValid;

            try
            {
                // Verify the user with the DB
                iCheckUser = userVerify.CheckLoginUser(strEmail, strPassword);
            }
            catch (Exception exc)
            {
                throw exc;
            }

            if (iCheckUser == 0)    // Either the account not registered or account has been disabled
            {
                lblUserExists.Text = "Email not registered or account has been disabled";
                lblUserExists.Visible = true;

                bValid = false;
            }
            else if (iCheckUser == 1)   // The password is incorrect
            {
                lblUserExists.Visible = false;

                lblInvalidPassword.Text = "Password incorrect";
                lblInvalidPassword.Visible = true;

                bValid = false;
            }
            else if (iCheckUser == 3)   // The account has not yet been verified
            {
                lblUserExists.Text = "Email has not yet been verified. Please check your email inbox";
                lblUserExists.Visible = true;

                bValid = false;
            }
            else    // Has passed all verification checks
            {
                lblUserExists.Visible = false;
                lblInvalidPassword.Visible = false;

                bValid = true;
            }

            if (IsValid && bValid)
            {
                try
                {
                    // Create a new session for the user
                    UserSession usCurrent = new UserSession(strEmail);
                    Session["userSession"] = usCurrent;

                    Response.Redirect("~/UL/Admin/AdminPortal.aspx");
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
        // Redirects to the Password Recovery Page
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/PasswordRecovery.aspx");
        }

        //On click handler for Register button - Sends to AdminRegister.aspx
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Admin/AdminRegister.aspx");
        }
    }
}