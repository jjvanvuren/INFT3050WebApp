using System;
using INFT3050WebApp.BL;

namespace INFT3050WebApp
{
    public partial class Logout : System.Web.UI.Page
    {
        // Logout message format
        const string LOGOUT_FORMAT = "Thank you for shopping with us {0}.";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Use the customers name stored in session data to display the logout message
            UserSession query = (UserSession)Session[UserSession.SESSION_KEY];
            if (query != null)
            {
                User currentUser = new User(query.SessionId);

                lblLogoutMessage.Text = String.Format(LOGOUT_FORMAT, currentUser.FirstName);
            }

            // Clear all session data once user has logged out
            Session.Clear();
        }
    }
}