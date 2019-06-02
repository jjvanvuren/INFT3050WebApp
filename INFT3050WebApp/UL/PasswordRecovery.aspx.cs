using System;
using System.Configuration;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/PasswordRecovery.aspx";
                Response.Redirect(url);
            }
        }

        // Redirects to the Password Recovery Page
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Clear the session incase still logged in
            Session.Clear();

            User userVerify = new User();
            bool bUserExists;

            try
            {
                // Check if the user exists on the DB
                bUserExists = userVerify.UserExists(tbxEmail.Text);
            }
            catch (Exception exc)
            {
                throw exc;
            }

            if (IsValid)
            {
                // If the email exists
                if (bUserExists)
                {
                    try
                    {
                        // Send recovery email
                        userVerify.SendResetPassword(tbxEmail.Text);
                        Response.Redirect("~/UL/RecoveryEmailSent.aspx");
                    }
                    catch (Exception exc)
                    {

                        throw exc;
                    }
                }
                else
                {
                    // Display the message to the user
                    lblUserExists.Text = "Email not registered or account has been disabled";
                    lblUserExists.Visible = true;
                }
            }
        }
    }
}