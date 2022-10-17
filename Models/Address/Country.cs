using System;
namespace ScamTroller.Models.Address
{
    public class Country
    {
        public string Name;
        public string Alpha2;
        public string Alpha3;
        public string CountryCode;
        public string Region;

        public Country()
        {
        }

        public static Country FromStr(string value)
        {
            string[] segments = value.Split(',');
            return new Country
            {
                Name = segments[0],
                Alpha2 = segments[1],
                Alpha3 = segments[2],
                CountryCode = segments[3],
                Region = segments[5]
            };
        }
    }
}

