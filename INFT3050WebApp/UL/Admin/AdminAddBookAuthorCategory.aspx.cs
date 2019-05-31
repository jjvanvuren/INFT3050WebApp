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

            BL.AddBookSession populateGridView = (BL.AddBookSession)Session["addBookSession"];
            GridAddedAuthors.DataSource = populateGridView.addedAuthors();
            GridAddedAuthors.DataBind();
            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

        }

        //Used when Add Button is prested to add the Author to the List of Authors in Session Data.
        //Calls the session to handle the add
        protected void GridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //When clicking the add button Add the author to book session
            if (e.CommandName == "cmdAdd")
            {
                try
                {
                    BL.Author newAuthor = new BL.Author();
                    newAuthor = newAuthor.getAuthor(Int32.Parse(e.CommandArgument.ToString()));

                    BL.AddBookSession AddAuthors = (BL.AddBookSession)Session["addBookSession"];
                    AddAuthors.AddAuthorToBook(newAuthor);
                    Response.Redirect("~/UL/Admin/AdminAddBookAuthorCategory.aspx");

                }
                catch (Exception)
                {
                    Server.Transfer("~/UL/DefaultError.aspx?handler=.aspx", true);
                }

            }

        }

        //Search Button Adding Parameters to the GridView source and if not found shows a button.
        protected void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            authorDataSource.SelectParameters.Clear();AdminAddBookAuthorCategory
            //Stops from adding of an Author that is already in the Database.
            lblNoAuthor.Visible = false;
            btnNewAuthor.Visible = false;
            authorDataSource.SelectParameters.Add("SearchFirstName", tbxFirstName.Text);
            authorDataSource.SelectParameters.Add("SearchLastName", tbxLastName.Text);

            this.GridAuthors.DataBind();
            //If no Authors were found will show add Author button to Add the Author.
            if (GridAuthors.Rows.Count == 0)
            {
                lblNoAuthor.Visible = true;
                btnNewAuthor.Visible = true;
            }
        }

        //FIX NEEDED
        protected void btnNewAuthor_Click(object sender, EventArgs e)
        {
            string NewAuthorFirstName = tbxFirstName.Text;
            string NewAuthorLastName = tbxLastName.Text;
            //Adding Author to Data base
            BL.Author newAuthor = new BL.Author(tbxFirstName.Text, tbxLastName.Text);
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

        //Continue button will Grab the checked Categories and Add them to the list.
        protected void btnComfirmToContiue_Click(object sender, EventArgs e)
        {
            BL.AddBookSession populateGridView = (BL.AddBookSession)Session["addBookSession"];
            List<int> CategoryList = new List<int>();
            //add check slected Category to the session.
            foreach (GridViewRow gvrow in gvCategory.Rows)
            {
                CheckBox chk = gvrow.FindControl("Select") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    CategoryList.Add(Int32.Parse(gvrow.Cells[2].Text));
                }
            }

            populateGridView.AddCategoryToBook(CategoryList);

            if (populateGridView.Authors.Count >0 && populateGridView.Categories.Count > 0)
            {
                Response.Redirect("~/UL/Admin/AdminAddBookComfirmation.aspx");
            }
        }
    }
}

 try
                {


                }
                catch (Exception)
                {
                    Server.Transfer("~/UL/DefaultError.aspx?handler=AdminPostageOptions.aspx", true);
                }
                finally
                {
                    this.PostageOptionManagement.DataBind();
                }