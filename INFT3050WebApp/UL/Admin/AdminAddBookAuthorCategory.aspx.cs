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
            DataBind();
            //if (Session["UserSession"] == null)
            //{
            //    Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            //}

        }

        protected void GridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When clicking the View button take the user to the matching book's page
            //if (e.CommandName == "cmdAdd")
            //{
            //    BL.Author newAuthor = new BL.Author();
            //    //Returning Created Author to Add to Session
            //    //newAuthor = newAuthor.getAuthor(e.CommandArgument);

            //    BL.AddBookSession AddAuthors = (BL.AddBookSession)Session["addBookSession"];
            //    AddAuthors.AddAuthorID(newAuthor);
            //    Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");
            //}

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
            //Adding Author to Data base
            BL.Author newAuthor = new BL.Author(tbxFirstName.Text, tbxLastName.Text);
            //Returning Created Author to Add to Session
            newAuthor = newAuthor.getAddAuthor(tbxFirstName.Text, tbxLastName.Text);
      
            BL.AddBookSession AddAuthors = (BL.AddBookSession)Session["addBookSession"];
            AddAuthors.AddAuthorID(newAuthor);
            Session["addBookSession"] = AddAuthors;
            //Hiding Add Labels after add
            lblNoAuthor.Visible = false;
            btnNewAuthor.Visible = false;
            Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");
        }

        protected void btnComfirmToContiue_Click(object sender, EventArgs e)
        {

        }




    }
}