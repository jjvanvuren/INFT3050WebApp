using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminAddBookAuthorCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserSession"] == null)
            //{
            //    Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            //}

        }

        protected void GridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When clicking the View button take the user to the matching book's page
            if (e.CommandName == "cmdView")
            {
                Response.Redirect("Book.aspx?id=" + e.CommandArgument);
            }

        }
        protected void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            authorDataSource.SelectParameters.Clear();
            authorDataSource.SelectParameters.Add("SearchFirstName", tbxFirstName.Text);
            authorDataSource.SelectParameters.Add("SearchLastName", tbxLastName.Text);

            this.GridAuthors.DataBind();
            if (GridAuthors.Rows.Count == 0)
            {
                lblNoAuthor.Visible = true;
                btnNewAuthor.Visible = true;
            }
        }

        protected void btnNewAuthor_Click(object sender, EventArgs e)
        {
           string NewAuthorFirstName = tbxFirstName.Text;
           string NewAuthorLastName = tbxLastName.Text;
           
        }

        


    }
}