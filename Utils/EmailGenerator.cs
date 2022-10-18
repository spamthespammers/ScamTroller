using System;
using System.Text;
using ScamTroller.Extensions;

namespace ScamTroller.Utils
{
    public static class EmailGenerator
    {
        static Random Random = new Random();
        static readonly string[] EmailDomains = { "gmail", "msn", "outlook" };

        public static string RandomEmail(string firstName, string lastName)
        {
            StringBuilder ret = new StringBuilder();

            switch(Random.Next(4))
            {
                case 0:
                    ret.Append($"{firstName}.{lastName}");
                    break;
                case 1:
                    ret.Append($"{firstName.Substring(0, 1)}{lastName}");
                    break;
                case 2:
                    ret.Append($"{firstName}{lastName}");
                    break;
                case 3:
                    ret.Append($"{lastName}.{firstName}");
                    break;
            }

            if (RandomUtils.RandomBool())
            {
                ret.Append($"{Random.Next(0, 13)}{Random.Next(28):00}");
            }
            ret.Append($"@{EmailDomains.SelectRandom()}.com");

            return ret.ToString().ToLowerInvariant();
        }
    }
}

