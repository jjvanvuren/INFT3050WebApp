using System;
using System.Configuration;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL
{
    public partial class NewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/NewPassword.aspx";
                Response.Redirect(url);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            User uUser;
            bool bVerified;

            // Get the email and key from the url
            string strEmail = Request.QueryString["email"];
            string strKey = Request.QueryString["key"];

            try
            {
                // Verify the user with the DB
                User user = new User(strEmail);
                uUser = user;

                bVerified = uUser.Verify(strEmail, strKey);
            }
            catch (Exception exc)
            {
                throw exc;
            }

            if (IsValid)
            {
                // If the email exists
                if (bVerified)
                {
                    uUser.Password = tbxPassword.Text;

                    try
                    {
                        // Update the password in the DB
                        uUser.ResetPassword();
                        Response.Redirect("~/UL/SuccessfulPasswordRecovery.aspx");
                    }
                    catch (Exception exc)
                    {
                        throw exc;
                    }
                }
                else
                {
                    // Show error message
                    lblError.Text = "Error: Password reset validation failed. Please try resetting your password again.";
                    lblError.Visible = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Login.aspx");
        }
    }
}