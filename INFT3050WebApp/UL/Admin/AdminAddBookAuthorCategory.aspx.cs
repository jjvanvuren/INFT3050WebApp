using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminAddBookAuthorCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Enable SSL
                if (!Request.IsSecureConnection)
                {
                    string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminAddBookAuthorCategory.aspx";
                    Response.Redirect(url);
                }
                if (Session["addBookSession"] == null)
                {
                    Response.Redirect("~/UL/Admin/AdminPortal.aspx");
                }
                if (Session["UserSession"] == null)
                {
                    Response.Redirect("~/UL/Admin/AdminLogin.aspx");
                }
                BL.AddBookSession populateGridView = (BL.AddBookSession)Session["addBookSession"];
                GridAddedAuthors.DataSource = populateGridView.addedAuthors();
                GridAddedAuthors.DataBind();
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        protected void GridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //When clicking the add button Add the author to book session
            try { 
                if (e.CommandName == "cmdAdd")
                {
                    BL.Author newAuthor = new BL.Author();
                    newAuthor = newAuthor.getAuthor(Int32.Parse(e.CommandArgument.ToString()));

                    BL.AddBookSession AddAuthors = (BL.AddBookSession)Session["addBookSession"];
                    AddAuthors.AddAuthorToBook(newAuthor);
                    Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        //search for an Author by name - searching by just first Name and/or Last Name
        protected void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            try {
                authorDataSource.SelectParameters.Clear();
                authorDataSource.SelectParameters.Add("SearchFirstName", tbxFirstName.Text);
                authorDataSource.SelectParameters.Add("SearchLastName", tbxLastName.Text);
                //stop admin admin for searching unknown author then searching a another and trying to add
                lblNoAuthor.Visible = false;
                btnNewAuthor.Visible = false;
                this.GridAuthors.DataBind();
                //If no results are returned allows admin to add author(
                if (GridAuthors.Rows.Count == 0)
                {
                    lblNoAuthor.Visible = true;
                    btnNewAuthor.Visible = true;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        //handles the button click that starts the adding of a new Author to the DB
        protected void btnNewAuthor_Click(object sender, EventArgs e)
        {
            try { 
                string NewAuthorFirstName = tbxFirstName.Text;
                string NewAuthorLastName = tbxLastName.Text;
                BL.Author newAuthor = new BL.Author();
                //Adding Author to Data base
                if (tbxFirstName.Text != null)
                {
                    newAuthor = new BL.Author(tbxFirstName.Text, tbxLastName.Text);
                }
                //Returning Created Author to Add to Session
                newAuthor = newAuthor.getAddAuthor(tbxFirstName.Text, tbxLastName.Text);

                BL.AddBookSession AddAuthors = (BL.AddBookSession)Session["addBookSession"];
                AddAuthors.AddAuthorToBook(newAuthor);
                Session["addBookSession"] = AddAuthors;
                //Hiding Add Labels after add
                lblNoAuthor.Visible = false;
                btnNewAuthor.Visible = false;
                Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        //Handles the contue click  
        protected void btnComfirmToContiue_Click(object sender, EventArgs e)
        {
            try { 
                BL.AddBookSession populateGridView = (BL.AddBookSession)Session["addBookSession"];
                List<int> CategoryList = new List<int>();
                //add check selected Categories to the book session.
                foreach (GridViewRow gvrow in gvCategory.Rows)
                {
                    CheckBox chk = gvrow.FindControl("Select") as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        CategoryList.Add(Int32.Parse(gvrow.Cells[2].Text));
                    }
                }

                populateGridView.AddCategoryToBook(CategoryList);
                //stops from a book being added with no author and no category
                if (populateGridView.Authors.Count >0 && populateGridView.Categories.Count > 0)
                {
                    Response.Redirect("~/UL/Admin/AdminAddBookComfirmation.aspx");
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}