using System;
using ScamTroller.Extensions;

namespace ScamTroller.Utils
{
    public class NameGenerator
    {
        private static IEnumerable<string> FirstNames { get; }
        private static IEnumerable<string> LastNames { get; }

        private List<string> UsedFirstNames = new List<string>();
        private List<string> UsedLastNames = new List<string>();

        private void Reset()
        {
            UsedFirstNames.Clear();
            UsedLastNames.Clear();
        }

        static NameGenerator()
        {
            FirstNames = File.ReadAllLines("first-names.txt").Where(element => !string.IsNullOrEmpty(element));
            LastNames = File.ReadAllLines("last-names.txt").Where(element => !string.IsNullOrEmpty(element));
        }

        public NameGenerator()
        {

        }

        private static string Capitalize(string value) => $"{value.Substring(0, 1).ToUpper()}{value.Substring(1)}";
        public string GetFirstName()
        {
            string ret = FirstNames.SelectRandomUnused(UsedFirstNames);
            UsedFirstNames.Add(ret);
            return Capitalize(ret);
        }

        public string GetLastName()
        {
            string ret = LastNames.SelectRandomUnused(UsedLastNames);
            UsedLastNames.Add(ret);
            return Capitalize(ret);
        }

        public static string GetFirstNameRepeating() => Capitalize(FirstNames.SelectRandom());
        public static string GetLastNameRepeating() => Capitalize(LastNames.SelectRandom());


    }
}

