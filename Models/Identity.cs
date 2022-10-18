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


        public static Identity Fabricate()
        {
            string firstName = NameGenerator.GetFirstNameRepeating();
            string lastName = NameGenerator.GetLastNameRepeating();
            var creditCard = CreditCardGenerator.GenerateCreditCard();

            Bogus.Person person = new Bogus.Person();

            return new Identity
            {
                FirstName = firstName,
                LastName = lastName,
                StreetAddress = person.Address.Street,
                City = person.Address.City,
                State = AddressUtils.GetStateCode(person.Address.State), //person.Address.State,
                Country = "US",
                PostCode = person.Address.ZipCode,
                Email = EmailGenerator.RandomEmail(firstName, lastName),
                ExpirationMonth = creditCard.ExpMonth,
                ExpirationYear = creditCard.ExpYear,
                CreditCardNumber = creditCard.Number,
                CreditCardCVC = creditCard.CVV,
                Phone = person.Phone
               
            };
        }

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

