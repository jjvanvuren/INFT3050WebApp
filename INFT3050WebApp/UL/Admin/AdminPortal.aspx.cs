using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.BackEnd
{
    //On PreInit check session data to see if logged in if not send to AdminLogin.axpc
    public partial class BackEndEmployeePortal : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Button to add a new book to database: No functionality yet
        protected void btnAddBook_Click(object sender, EventArgs e)
        {
        }
    }
}