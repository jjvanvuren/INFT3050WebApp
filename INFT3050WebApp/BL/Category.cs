using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(){
        }
        public List<Category> getCategories() {

            List<Category> categories = new List<Category>();
            CategoryDataAccess search = new CategoryDataAccess();
            categories = search.GetCategory();

            return categories;
        }

        public Category (int iCategoryID)
        {
            // Set up access to database
            DAL.ICategoryDataAccess db = new DAL.CategoryDataAccess();

            Category category = db.GetCategoryById(iCategoryID);

            Id = category.Id;
            Name = category.Name;
            Description = category.Description;

        }
    }
}