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
    //On PreInit check session data to see if logged in if not send to AdminLogin.axpc
    public partial class AdminPostageOptions : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                //Enable SSL
                if (!Request.IsSecureConnection)
                {
                    string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminPostageOptions.aspx";
                    Response.Redirect(url);
                }
            }
        }

        protected void PostageOptionManagement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // If delete button was selected change status to inactive
            if (e.CommandName == "cmdDelete")
            {
                try
                {
                    string comString = e.CommandArgument.ToString();

                    if (!string.IsNullOrEmpty(comString) && int.TryParse(comString, out int id))
                    {
                        PostageOption postage = new PostageOption();

                        postage.DeletePostageOption(id);
                    }


                }
                catch (Exception exception)
                {
                    Server.Transfer("~/UL/DefaultError.aspx?handler=AdminPostageOptions.aspx", true);
                }
                finally
                {
                    this.PostageOptionManagement.DataBind();
                }

            }
        }

        protected void PostageOptionManagement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = PostageOptionManagement.Rows[e.RowIndex];
                string sID = row.Cells[0].Text;
                string updatedName = ((TextBox)row.Cells[1].FindControl("txtGridName")).Text;
                string updatedPrice = ((TextBox)row.Cells[2].FindControl("txtGridPrice")).Text;


                if (int.TryParse(sID, out int iID) && double.TryParse(updatedPrice, out double dPrice))
                {
                    PostageOption postage = new PostageOption();

                    int rowsAffected = postage.UpdatePostageOptionById(iID, dPrice, updatedName);
                }
            }
            catch (Exception)
            {
                Server.Transfer("~/UL/DefaultError.aspx?handler=AdminPostageOptions.aspx", true);
            }
            finally
            {
                Response.Redirect("~/UL/Admin/AdminPostageOptions.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string newName = txtAddName.Text;
                string newPrice = txtAddPrice.Text;


                if (double.TryParse(newPrice, out double dPrice))
                {
                    PostageOption postage = new PostageOption();

                    int rowsAffected = postage.AddPostageOption(newName, dPrice);
                }
            }
            catch (Exception)
            {
                Server.Transfer("~/UL/DefaultError.aspx?handler=AdminPostageOptions.aspx", true);
            }
            finally
            {
                Response.Redirect("~/UL/Admin/AdminPostageOptions.aspx");
            }
        }
    }
}