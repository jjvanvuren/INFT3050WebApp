using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class CustomerSession
    {
        public const string SESSION_KEY = "customerSession";
        public int SessionId { get; set; }
    }
}