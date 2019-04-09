using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class UserSession
    {
        public const string SESSION_KEY = "UserSession";
        public string Email { get; set; }
        public string Name { get; set; }
        public bool LoggedIn { get; set; }
    }
}