using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "My Account" link
            Master.AccountLinkEnabled = false;
            Master.AccountLinkVisible = false;

            // Hide and disable the "Logout" link
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create a new user based on info entered
                User registeredUser = new User(0, tbxEmail.Text, tbxPassword.Text, tbxFirstName.Text, tbxLastName.Text, false, "Active");

                // Data to be retained in session
                CustomerSession currentCustomerSession = new CustomerSession
                {
                    Email = tbxEmail.Text,
                    Name = tbxFirstName.Text + " " + tbxLastName.Text,
                    LoggedIn = true
                };

                Session["customerSession"] = currentCustomerSession;

                Response.Redirect("~/UL/SuccessfulRegistration.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default.aspx");
        }

        //public User CreateUser (int id, string email, string password, string firstName, string lastName, bool isAdmin, string status)
        //{
        //    User user = new User()
        //    {
        //        Id = id,
        //        Email = email,
        //        Password = password,
        //        FirstName = firstName,
        //        LastName = lastName,
        //        IsAdmin = isAdmin,
        //        Status = status
        //    };

        //    return user;
        //}
    }
}