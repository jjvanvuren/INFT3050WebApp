using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL
{
    public partial class ConfirmSale : System.Web.UI.Page
    {
        // Sale confirmation message format
        const string CONFIRM_SALE_FORMAT = "Thank you for shopping at the Used Book Store {0}. Your receipt has been sent to {1}. You will be notified once your order has been shipped.";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Use the customers name stored in session data to display the confirmation message
            CustomerSession query = (CustomerSession)Session[CustomerSession.SESSION_KEY];
            if (query != null)
            {
                confirmSaleMessageLabel.Text = String.Format(CONFIRM_SALE_FORMAT, query.Name, query.Email);
            }
        }
    }
}