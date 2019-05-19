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
            Session.Clear();

            // Create a new user based on info entered
            User registeredUser = new User(tbxEmail.Text, tbxPassword.Text, tbxFirstName.Text, tbxLastName.Text, true, true);

            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            // Check if email already exists in DB
            bool bRegistered = db.CheckUserExists(tbxEmail.Text);

            if (bRegistered)
            {
                lblEmailExists.Text = "Email already exists";
                lblEmailExists.Visible = true;
            }
            else
            {
                lblEmailExists.Visible = false;
            }

            if (IsValid)
            {
                int rowsAffected = db.RegisterUser(registeredUser);

                User currentUser = new User();

                currentUser = db.GetUserByEmail(registeredUser.Email);

                // Data to be retained in session
                UserSession currentUserSession = new UserSession
                {
                    SessionId = currentUser.Id
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