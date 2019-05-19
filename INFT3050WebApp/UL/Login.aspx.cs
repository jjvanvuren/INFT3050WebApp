using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check if user is logged in to use correct master page
            if (Session["customerSession"] != null)
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

                    Session["userSession"] = currentUserSession;

                    Response.Redirect("~/UL/Customer.aspx");
                }
            }
        }

        // Redirects to the Website home page
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default.aspx");
        }
    }
}