﻿using System;
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
        public bool IsAdmin { get; set; }
        public string Status { get; set; }
    }
}