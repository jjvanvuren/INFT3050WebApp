using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class Register : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Register.aspx";
                Response.Redirect(url);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Used for BL Validation
            bool bValid;

            try
            {
                // Create a new user based on info entered
                User registeredUser = new User(tbxEmail.Text, tbxPassword.Text, tbxFirstName.Text, tbxLastName.Text, false, true, "", true);


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

                    Response.Redirect("~/UL/SuccessfulRegistration.aspx");
                }
            }
            catch (Exception)
            {
                //string exceptionString = "?error=" + exception.Message;

                //if (exception.InnerException != null)
                //{
                //    exceptionString += "&innerex=" + exception.GetType().ToString() + "<br/>" + exception.InnerException.Message;
                //    exceptionString += "&stacktrace=" + exception.InnerException.StackTrace;
                //}
                //else
                //{
                //    exceptionString += "&innerex=" + exception.GetType().ToString();
                //    if (exception.StackTrace != null)
                //    {
                //        exceptionString += "&stacktrace=" + exception.StackTrace.ToString().TrimStart();
                //    }
                //}

                //Response.Redirect("DefaultError.aspx" + exceptionString);

                Server.Transfer("DefaultError.aspx?handler=Register.aspx", true);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default.aspx");
        }
    }
}