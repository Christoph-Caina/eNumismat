using System;
using System.Collections.Generic;

namespace eNumismat
{
    class Contact
    {
        public static Dictionary<string, string> ContactDetails = new Dictionary<string, string>();

        //=====================================================================================================================================================================
        public void SetContactDetails(String name, String surename, String gender = null, String birthdate = null, String street = null, String zipcode = null, String city = null, String country = null, String phone = null, String mobilephone = null, String email = null, String notes = null)
        {
            ContactDetails.Add("Name", name);
            ContactDetails.Add("Surename", surename);
            ContactDetails.Add("Gender", gender);
            ContactDetails.Add("BirthDate", birthdate);
            ContactDetails.Add("Street", street);
            ContactDetails.Add("ZipCode", zipcode);
            ContactDetails.Add("City", city);
            ContactDetails.Add("Country", country);
            ContactDetails.Add("Phone", phone);
            ContactDetails.Add("MobilePhone", mobilephone);
            ContactDetails.Add("Email", email);
            ContactDetails.Add("Notes", notes);
        }

        //=====================================================================================================================================================================
        public Dictionary<string, string> GetContactDetails()
        {
            return ContactDetails;
        }
    }
}
