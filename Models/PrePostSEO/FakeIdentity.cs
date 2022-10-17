using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScamTroller.Utils;

namespace ScamTroller.Models.PrePostSEO
{
    public class FakeIdentity
    {
        public string Name;
        public string Email;
        public string Phone;
        public string PostCode;
        public string StreetAddress;
        public string City;
        public string Country;
        public string State;
        public string Company;
        public string Gender;
        public Credit Credit;
        public string AccountNo;
        public string UserName;
        public int Age;
        public string DOB;
        public string Height;
        public string Weight;
        public string Hair;
        public string Eye;
        public string Bank;

        public string StateCode => AddressUtils.GetStateCode(State);

        public FakeIdentity()
        {
        }


    
    }
}

