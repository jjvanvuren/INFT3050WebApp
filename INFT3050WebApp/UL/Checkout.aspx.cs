﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using Microsoft.AspNet.FriendlyUrls;
using INFT3050.PaymentSystem;

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

            //this should receive a payment valid
            if (IsValid)
            {
                UserSession userSession = (UserSession)Session["userSession"];
                CartSession cartSession = (CartSession)Session["cartSession"];

                try
                {
                    int iPostCode = Int32.Parse(tbxPostCode.Text);
                    int iShippingId = Int32.Parse(ddlShippingMethod.SelectedValue);
                    //int iCVC = Int32.Parse(tbxSecurityCode.Text);

                    User user = new User(userSession.SessionId);

                    IPaymentSystem paymentSystem = INFT3050PaymentFactory.Create();
                    PaymentRequest payment = new PaymentRequest
                    {
                       // CardName = tbxCardName.Text,
                       // CardNumber = tbxCardNumber.Text,
                        //CVC = iCVC,
                        Expiry = new DateTime(2020, 11, 1),
                        Amount = 200,
                        Description = "test"
                    };


                    var task = paymentSystem.MakePayment(payment);

                    if (task.IsCompleted)

                    {
                        Address customerAddress = new Address(tbxStreetNumber.Text, tbxStreetName.Text, tbxCity.Text, ddlState.SelectedValue, iPostCode);

                        cartSession.submitCart(user.Id, customerAddress, iShippingId);

                        // Need to get the payment Id somehow.
                        int iPaymentId;

                        //Email for payment goes here
                        user.SendPaymentEmail(user.Id, iPaymentId);

                        var checkoutUrl = FriendlyUrl.Href("~/UL/ConfirmSale", task.Result.ToString());
                        Response.Redirect(checkoutUrl);
                    }

                    
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
            
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Cart.aspx");
        }
    }
}