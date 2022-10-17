using System;
using ScamTroller.Extensions;

namespace ScamTroller.Utils
{
    public static class EmailGenerator
    {
        static readonly string[] EmailDomains = { "gmail", "msn", "outlook" };

        public static string RandomEmail(string firstName, string lastName)
        {
            return $"{firstName.Substring(0)}.{lastName}@{EmailDomains.SelectRandom()}.com".ToLowerInvariant();
        }
    }
}

