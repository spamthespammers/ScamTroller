using System;
using ScamTroller.Models.PrePostSEO;
using ScamTroller.Utils;

namespace ScamTroller.Models
{
    public class Identity
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Phone;
        public string PostCode;
        public string StreetAddress;
        public string City;
        public string Country;
        public string State;
        public string CreditCardNumber;
        public string CreditCardCVC;
        public string ExpirationMonth;
        public string ExpirationYear;


        public Identity()
        {
        }

        public Identity(FakeIdentity identity)
        {
            FirstName = NameGenerator.GetFirstNameRepeating();
            LastName = NameGenerator.GetFirstNameRepeating();
            Email = EmailGenerator.RandomEmail(FirstName, LastName);
            State = identity.StateCode;
            City = identity.City;
            PostCode = identity.PostCode;
            StreetAddress = identity.StreetAddress;
            CreditCardNumber = identity.Credit.Number;
            ExpirationMonth = identity.Credit.ExpirationDate.Substring(0, 2);
            ExpirationYear = identity.Credit.ExpirationDate.Substring(3);
            CreditCardCVC = RandomUtils.RandomDigits(3);
            Phone = PhoneGenerator.RandomNumber();
        }

        public FormUrlEncodedContent ToProspectFormUrlEncodedContent()
        {
            return new FormUrlEncodedContent(new Dictionary<string, string>
            {
                    { "action", "prospect" },
                    { "firstName", FirstName },
                    { "lastName", LastName },
                    { "email", Email },
                    { "phone", Phone },
                    { "shippingCountry", "US" },
                    { "shippingZip", PostCode },
                    { "shippingAddress1", StreetAddress },
                    { "shippingAddress2", string.Empty },
                    { "shippingCity", City },
                    { "shippingState", State }
            });
        }

        public FormUrlEncodedContent ToDownsellFormUrlEncodedContent()
        {
            return new FormUrlEncodedContent(new Dictionary<string, string>
            {
                    { "firstName", FirstName },
                    { "lastName", LastName },
                    { "email", Email },
                    { "phone", Phone },
                    { "shippingCountry", "US" },
                    { "shippingZip", PostCode },
                    { "shippingAddress1", StreetAddress },
                    { "shippingAddress2", string.Empty },
                    { "shippingCity", City },
                    { "shippingState", State },
                    { "billing_checkbox", "yes" },
                    { "billingSameAsShipping", "yes" },
                    { "creditCardType", "visa" },
                    { "creditCardNumber", CreditCardNumber },
                    { "expmonth", ExpirationMonth },
                    { "expyear", ExpirationYear },
                    { "CVV", CreditCardCVC },
            });
        }

    }
}

