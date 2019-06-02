using System;
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
            // Check if user is logged in
            if (Session["userSession"] != null)
            {
                Page.MasterPageFile = "~/UL/Customer.Master";
            }
            else
            {
                // Check if the session has expired
                Response.Redirect("SessionExpired.aspx");
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
                lblProcessing.Visible = true;
                lblProcessing.Text = "Processing Payment...";
                lblProcessing.CssClass = "text-info";

                UserSession userSession = (UserSession)Session["userSession"];
                CartSession cartSession = (CartSession)Session["cartSession"];

                try
                {
                    int iPostCode = Int32.Parse(tbxPostCode.Text);
                    int iShippingId = Int32.Parse(ddlShippingMethod.SelectedValue);

                    // Values to be used by PaymentSystem
                    int iCVC = Int32.Parse(tbxSecurityCode.Text);
                    int iDateYear = Int32.Parse(ddlYear.SelectedValue);
                    int iDateMonth = Int32.Parse(ddlMonth.SelectedValue);
                    decimal dAmount = (decimal)cartSession.totalPrice;

                    string strDescriptionFormat = "Used Books Store Purchase: {0}/{1}/{2}";

                    User user = new User(userSession.SessionId);

                    IPaymentSystem paymentSystem = INFT3050PaymentFactory.Create();
                    PaymentRequest payment = new PaymentRequest
                    {
                        CardName = tbxCardName.Text,
                        CardNumber = tbxCardNumber.Text,
                        CVC = iCVC,
                        Expiry = new DateTime(iDateYear, iDateMonth, 1),
                        Amount = dAmount,
                        Description = string.Format(strDescriptionFormat, DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())
                    };

                    // Make the payment
                    var task = paymentSystem.MakePayment(payment);

                    // Wait for payment to be processed
                    task.Wait();

                    string tResult = task.Result.TransactionResult.ToString();

                    if (task.IsCompleted && tResult == "Approved")
                    {
                        Address customerAddress = new Address(tbxStreetNumber.Text, tbxStreetName.Text, tbxCity.Text, ddlState.SelectedValue, iPostCode);

                        cartSession.submitCart(user.Id, customerAddress, iShippingId);

                        // Submit the order details to the db
                        int iPaymentId= cartSession.submitCart(user.Id, customerAddress, iShippingId); ;

                        // Send payment confirmation email to customer
                        user.SendPaymentEmail(user.Id, iPaymentId);

                        var checkoutUrl = FriendlyUrl.Href("~/UL/ConfirmSale");
                        Response.Redirect(checkoutUrl);
                    }
                    else if (task.IsCompleted && tResult == "Declined")
                    {
                        lblProcessing.Text = "Payment transaction declined";
                        lblProcessing.CssClass = "text-danger";
                    }
                    else
                    {
                        lblProcessing.Text = "Payment transaction failed, please try again";
                        lblProcessing.CssClass = "text-danger";
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