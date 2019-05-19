using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.UL.BackEnd
{
    public partial class BackEndLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            // Used for BL Validation
            bool bValid;

            User userVerify = new User();
            int iCheckUser = userVerify.CheckUser(strEmail, strPassword);

            if (iCheckUser == 0)
            {
                lblUserExists.Text = "Email not registered or account has been disabled";
                lblUserExists.Visible = true;

                bValid = false;
            }
            else if (iCheckUser == 1)
            {
                lblUserExists.Visible = false;

                lblInvalidPassword.Text = "Password incorrect";
                lblInvalidPassword.Visible = true;

                bValid = false;
            }
            else
            {
                lblUserExists.Visible = false;
                lblInvalidPassword.Visible = false;

                bValid = true;
            }

            if (IsValid && bValid)
            {
                if (iCheckUser == 2)
                {
                    // Setup access to database
                    IUserDataAccess db = new UserDataAccess();

                    // Get the user from db using the GetUserByEmail method
                    User user = db.GetUserByEmail(strEmail);

                    UserSession currentUserSession = new UserSession()
                    {
                        SessionId = user.Id
                    };

                    Session["UserSession"] = currentUserSession;

                    Response.Redirect("~/UL/Admin/AdminPortal.aspx");
                }
            }
        }

        //On click handler for Register button - Sends to AdminRegister.aspx
        protected void btnRegister_Click(object sender, EventArgs e)
        {
                Response.Redirect("~/UL/Admin/AdminRegister.aspx");
        }
    }
}