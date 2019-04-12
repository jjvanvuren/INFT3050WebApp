using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

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
            if (IsValid)
            {
                Session.Clear();

                CustomerSession currentCustomerSession = new CustomerSession()
                {
                    Email = tbxEmail.Text,
                    Name = "Joe Smith",
                    LoggedIn = true
                };

                Session["customerSession"] = currentCustomerSession;

                Response.Redirect("~/UL/Customer.aspx");
            }
        }

        // Checks if customer email exists
        // This is only temporary. Will change in next assignment
        protected void customerRegistered(object source, ServerValidateEventArgs args)
        {
            if (tbxEmail.Text == "joe@example.com")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        // Checks if customer password is correct
        // This is only temporary. Will change in next assignment
        protected void passwordCorrect(object source, ServerValidateEventArgs args)
        {
            if (tbxPassword.Text == "password")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        // Redirects to the Website home page
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default.aspx");
        }
    }
}