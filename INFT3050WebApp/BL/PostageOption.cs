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

        // Method to "delete" a postage option by calling DeletePostageOptionById from the DAL
        public int DeletePostageOption(int Id)
        {
            
            var db = new PostageOptionDataAccess();

            int rowsAffected = db.DeletePostageOptionById(Id);

            return rowsAffected;
        }

        // Method to update postage option by calling UdatePostageOptionById from the DAL
        public int UpdatePostageOptionById(int Id, double price, string name)
        {
            var db = new PostageOptionDataAccess();

            int rowsAffected = db.UpdatePostageOptionById(Id, price, name);

            return rowsAffected;
        }

        // Method to add a new postage option to the database by calling the AddPostageOption method in the DAL
        public int AddPostageOption(string name, double price)
        {
            var db = new PostageOptionDataAccess();

            int rowsAffected = db.AddPostageOption(name, price);

            return rowsAffected;
        }

        public PostageOption GetPostOption(int PostageOptionID)
        {
            //adding postage option to te total cost.
            DAL.PostageOptionDataAccess postageConnect = new DAL.PostageOptionDataAccess();
            return  postageConnect.GetPostageOption(PostageOptionID);
        }
    }
}