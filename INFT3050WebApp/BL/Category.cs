using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category() { }

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