using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IsAdmin { get; set; }
        public int IsActive { get; set; }

        public User() { }

        public User (int id, string email, string password, string firstName, string lastName, int isAdmin, int status)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsAdmin = isAdmin;
            this.IsActive = status;

        }
    }
}