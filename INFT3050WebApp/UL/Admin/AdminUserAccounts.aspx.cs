using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminUserAccounts : System.Web.UI.Page
    {
        //On PreInit check session data to see if logged in if not send to AdminLogin.axpc
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserSession"] == null)
            {
               Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminUserAccounts.aspx";
                Response.Redirect(url);
            }
        }

        protected void UserManagement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdView")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = UserManagement.Rows[index];

                string sID = Server.HtmlDecode(row.Cells[0].Text);

                Response.Redirect("~/UL/Admin/AdminPurchaseHistory.aspx?Id=" + sID);
            }

            else if (e.CommandName == "cmdActivate")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    GridViewRow row = UserManagement.Rows[index];

                    string sID = Server.HtmlDecode(row.Cells[0].Text);

                    if (!string.IsNullOrEmpty(sID) && int.TryParse(sID, out int id))
                    {
                        User user = new User();

                        user.ActivateUserById(id);
                    }

                }
                catch (Exception exception)
                {
                    Server.Transfer("~/UL/DefaultError.aspx?handler=AdminUserAccounts.aspx", true);
                }
                finally
                {
                    this.UserManagement.DataBind();
                }
            }

            else if (e.CommandName == "cmdDeactivate")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    GridViewRow row = UserManagement.Rows[index];

                    string sID = Server.HtmlDecode(row.Cells[0].Text);

                    if (!string.IsNullOrEmpty(sID) && int.TryParse(sID, out int id))
                    {
                        User user = new User();

                        user.DeactivateUserById(id);
                    }


                }
                catch (Exception exception)
                {
                    Server.Transfer("~/UL/DefaultError.aspx?handler=AdminUserAccounts.aspx", true);
                }
                finally
                {
                    this.UserManagement.DataBind();
                }
            }

        }
    }
}