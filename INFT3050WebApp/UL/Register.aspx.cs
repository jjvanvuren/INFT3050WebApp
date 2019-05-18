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
    public partial class Register : System.Web.UI.Page
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create a new user based on info entered
                User registeredUser = new User(tbxEmail.Text, tbxPassword.Text, tbxFirstName.Text, tbxLastName.Text, false, true);

                // Setup access to database
                IUserDataAccess db = new UserDataAccess();

                int rowsAffected = db.RegisterUser(registeredUser);

                User currentUser = new User();
                currentUser = db.GetUserByEmail(registeredUser.Email);

                // Data to be retained in session
                CustomerSession currentCustomerSession = new CustomerSession
                {
                    SessionId = currentUser.Id
                };

                Session["customerSession"] = currentCustomerSession;

                Response.Redirect("~/UL/SuccessfulRegistration.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default.aspx");
        }
    }
}