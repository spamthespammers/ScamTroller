using System;
using ScamTroller.Models.Address;

namespace ScamTroller.Utils
{
    public static class AddressUtils
    {

        static List<State> States = new List<State>();
        static List<Country> Countries = new List<Country>();
        
        static AddressUtils()
        {
            States = File.ReadAllLines("states.csv").Select(element => State.FromStr(element)).ToList();
            Countries = File.ReadAllLines("countries.csv").Select(element => Country.FromStr(element)).ToList();

        }

        public static string? GetStateCode(string name)
        {
            return States.FirstOrDefault(element => element.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))?.Alpha2;
        }

    }
}

