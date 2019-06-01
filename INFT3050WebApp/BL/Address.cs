using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class Address
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int postCode { get; set; }

        public Address() { }

        public Address(string strStreetNumber, string strStreetName, string strCity, string strState, int iPostCode)
        {
            this.StreetNumber = strStreetNumber;
            this.StreetName = strStreetName;
            this.City = strCity;
            this.State = strState;
            this.postCode = iPostCode;
        } 
    }
}