﻿using System;
using System.Configuration;
using System.Web.UI;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class Login : System.Web.UI.Page
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
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Login.aspx";
                Response.Redirect(url);
            }
        }

        // Validate email and password. If successful redirect to Customer.aspx
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strEmail = tbxEmail.Text;
            string strPassword = tbxPassword.Text;
            

            // Used for BL Validation
            bool bValid;
            int iCheckUser;
            User userVerify = new User();

            try
            {
                // Verify the user with the DB
                iCheckUser = userVerify.CheckLoginUser(strEmail, strPassword);
            }
            catch (Exception exc)
            {
                throw exc;
            }

            if (iCheckUser == 0)    // Either the account not registered or account has been disabled
            {
                lblUserExists.Text = "Email not registered or account has been disabled";
                lblUserExists.Visible = true;

                bValid = false;
            }
            else if (iCheckUser == 1)   // The password is incorrect
            {
                lblUserExists.Visible = false;

                lblInvalidPassword.Text = "Password incorrect";
                lblInvalidPassword.Visible = true;

                bValid = false;
            }
            else if (iCheckUser == 3)   // The account has not yet been verified
            {
                lblUserExists.Text = "Email has not yet been verified. Please check your email inbox";
                lblUserExists.Visible = true;

                bValid = false;
            }
            else    // Has passed all verification checks
            {
                lblUserExists.Visible = false;
                lblInvalidPassword.Visible = false;

                bValid = true;
            }

            if (IsValid && bValid)  // Has passed form validation & all verification checks
            {
                try
                {
                    // Create a new session for the user
                    UserSession usCurrent = new UserSession(strEmail);
                    Session["userSession"] = usCurrent;

                    Response.Redirect("~/UL/Customer.aspx");
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }

        // Redirects to the Password Recovery Page
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/PasswordRecovery.aspx");
        }

        // Redirects to the Website home page
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default.aspx");
        }
    }
}