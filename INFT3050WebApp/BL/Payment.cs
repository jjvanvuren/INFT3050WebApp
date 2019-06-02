using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DatePayed { get; set; }
        public float Total { get; set; }
    }
}