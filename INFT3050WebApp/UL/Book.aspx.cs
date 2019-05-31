using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using Microsoft.AspNet.FriendlyUrls;

namespace INFT3050WebApp.UL
{
    public partial class Book : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check if user is logged in to use correct master page
            if (Session["userSession"] != null)
            {
                Page.MasterPageFile = "~/UL/Customer.Master";
            }
            else
            {
                Page.MasterPageFile = "~/UL/Site.Master";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var segments = Request.GetFriendlyUrlSegments();
            int count = segments.Count;
            string idString = segments[0];

            // Get ID and try parse
            //var idString = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
            {

                if (!IsPostBack)
                {
                    try
                    {
                        BL.Book book = new BL.Book(id);
                        if (book != null)
                        {
                            // Use data for page elements
                            lblTitle.Text = book.Title;
                            imgBook.ImageUrl = book.ImagePath;
                            lblDescription.Text = book.LongDescription;
                            lblPrice.Text = "Price: $" + book.Price.ToString();
                            string listOfAuthorsDisplay = "Writen by: ";
                            foreach (Author author in book.Authors)
                            {
                                listOfAuthorsDisplay += author.FirstName + " " + author.LastName;
                                if (book.Authors.Count == 1 || book.Authors.IndexOf(author) == book.Authors.Count - 1)
                                {

                                }
                                else
                                {
                                    listOfAuthorsDisplay += ", ";
                                }
                            }

                            lblAuthor.Text = listOfAuthorsDisplay;
                            lblQuantity.Text = "In Stock: " + book.StockQuantity.ToString();
                            lblPublisher.Text = "Published: " + book.Publisher;
                            lblDatePublished.Text = book.DatePublished.ToShortDateString();
                        }
                    }
                    catch (Exception exc)
                    {
                        throw exc;
                    }
        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            // Get ID and try parse
            var idString = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
            {

                //if (!IsPostBack)
                //{
                    try
                    {
                        BL.Book book = new BL.Book(id);

                        if (Session["cartSession"] == null)
                        {
                            BL.CartSession cartCurrent = new BL.CartSession();
                            Session["cartSession"] = cartCurrent;
                        }

                        CartSession csCart = (CartSession)Session["cartSession"];
                        CartItem cartItem = new CartItem(book.Id, 1);

                            csCart.AddItem(cartItem);
                            Response.Redirect("~/UL/Cart.aspx");
                    }
                    catch (Exception exception)
                    {
                        Server.Transfer("DefaultError.aspx?handler=Book.aspx", true);
            }
                }
        }

                    }

}
            }
        }
    }
}