using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class PostageOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public PostageOption() { }

        // Method to get all active postage options from database
        public List<PostageOption> GetPostageOptions()
        {
            var db = new PostageOptionDataAccess();
            var postageOptions = db.GetPostageOptions();

            List<PostageOption> allPostageOptions = new List<PostageOption>();

            foreach (PostageOption postageOption in postageOptions)
            {
                allPostageOptions.Add(postageOption);
            }

            return allPostageOptions;
        }

        public int DeletePostageOption(int Id)
        {
            
            var db = new PostageOptionDataAccess();

            int rowsAffected = db.DeletePostageOptionById(Id);

            return rowsAffected;
        }
    }
}