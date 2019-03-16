using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Validate email and password. If successful redirect to Default.aspx
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxEmail.Text == "" && tbxPassword.Text == "")
            {
                lblEmail.Text = "Please enter your email address";
                lblEmail.ForeColor = System.Drawing.Color.Red;
                lblPassword.Text = "Please enter your password";
                lblPassword.ForeColor = System.Drawing.Color.Red;
            }
            else if (tbxEmail.Text != "john.smith@example.com" && tbxPassword.Text != "password#1")
            {
                lblEmail.Text = "Email does not exist";
                lblEmail.ForeColor = System.Drawing.Color.Red;
                lblPassword.Text = "Password incorrect";
                lblPassword.ForeColor = System.Drawing.Color.Red;
            }
            else if (tbxEmail.Text == "")
            {
                lblEmail.Text = "Please enter your email address";
                lblEmail.ForeColor = System.Drawing.Color.Red;
            }
            else if (tbxEmail.Text != "john.smith@example.com")
            {
                lblEmail.Text = "Email does not exist";
                lblEmail.ForeColor = System.Drawing.Color.Red;
            }
            else if (tbxPassword.Text == "")
            {
                lblPassword.Text = "Please enter your password";
                lblPassword.ForeColor = System.Drawing.Color.Red;
            }
            else if (tbxPassword.Text != "password#1")
            {
                lblPassword.Text = "Password incorrect";
                lblPassword.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                //btnLogin.CssClass = "btn btn-success";
                //btnLogin.Text = "Success!";
                Response.Redirect("~/Default.aspx");
            }
   
        }
    }
}