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
        //Methord checks to see if state and state have a postcode in the DB
        //if it doesn't will enter it into the DB
        //With out implementing a full list of all postcodes with state and city
        //enters the postcode
        public void CheckPostCode()
        {
            DAL.OrderDataAccess connect = new DAL.OrderDataAccess();
            List<Address> listOfPostcodes = new List<Address>();
            listOfPostcodes = connect.GetPostCodes();
            Boolean postcodeFount = false;
            int i = 0;
            while (i<listOfPostcodes.Count() && !postcodeFount)
            {
                if(listOfPostcodes[i].State.Equals(State)&& listOfPostcodes[i].City.Equals(City))
                {
                    postcodeFount = true;
                }
                i++;
            }
            if (!postcodeFount)
            {
                connect.AddPostCode(City, State, postCode);
            }
        }
    }
}