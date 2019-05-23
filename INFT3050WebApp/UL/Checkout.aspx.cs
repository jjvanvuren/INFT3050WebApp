﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class Checkout : System.Web.UI.Page
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
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Checkout.aspx";
                Response.Redirect(url);
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("~/UL/CardPayment.aspx");
            }
            
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Cart.aspx");
        }
    }
}