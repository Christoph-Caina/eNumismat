using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNumismat
{
    class Contact
    {
        string[] ContactDetails = new string[] { };

        //=============================================================================================================
        public void SetContactDetails(String name, String surename, String gender = null, String birthdate = null, String street = null, String zipcode = null, String city = null, String country = null, String phone = null, String mobilephone = null, String email = null)
        {
            ContactDetails[0]  = name;
            ContactDetails[1]  = surename;
            ContactDetails[2]  = gender;
            ContactDetails[3]  = birthdate;
            ContactDetails[4]  = street;
            ContactDetails[5]  = zipcode;
            ContactDetails[6]  = city;
            ContactDetails[7]  = country;
            ContactDetails[8]  = phone;
            ContactDetails[9]  = mobilephone;
            ContactDetails[10] = email;
        }

        //=============================================================================================================
        public String[] GetContactDetails()
        {
            return ContactDetails;
        }
    }
}
