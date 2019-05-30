using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class StoreItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }

        public Boolean IsActive { get; set;}

        public StoreItem() { }

    }
}