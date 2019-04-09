using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFT3050WebApp.BL
{
    public class Customer : User
    {
        private Address myShipping;

        public Address Shipping
        {
            get
            {
                return myShipping;
            }

            set
            {
                if (HasShipping)
                {
                    myShipping = value;
                }
                else
                {
                    myShipping = Billing;
                }
            }
        }

        public Address Billing { get; set; }
        public bool HasShipping { get; set; }

    }
}