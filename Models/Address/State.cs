using System;
namespace ScamTroller.Models.Address
{
    public class State
    {
        public string Name;
        public string Alpha2;

        public State()
        {
        }

        public static State FromStr(string value)
        {
            string[] segments = value.Split(',').Select(element => element.Replace("\"", string.Empty)).ToArray();
            return new State
            {
                Name = segments[0],
                Alpha2 = segments[1]
            };
        }

    }
}

