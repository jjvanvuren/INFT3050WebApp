﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class Book : StoreItem
    {
        public string Isbn { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string SecondaryTitle { get; set; }

        // Need to remove Author & Category
        public Author Author { get; set; } 
        public Category Category { get; set; }

        public string Publisher { get; set; }
        public bool IsBestSeller { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}