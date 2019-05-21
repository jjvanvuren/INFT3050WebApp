using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class UserSession
    {
        public const string SESSION_KEY = "userSession";
        public int SessionId { get; set; }

        public UserSession() { }

        public UserSession (string strEmail)
        {
            // Setup access to database
            IUserDataAccess db = new UserDataAccess();

            // Get the user from db using the GetUserByEmail method
            User user = db.GetUserByEmail(strEmail);

            this.SessionId = user.Id;
        }
    }
}