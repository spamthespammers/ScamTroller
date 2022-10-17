using System;
namespace ScamTroller.Utils
{
    public static class PhoneGenerator
    {
        public static string RandomNumber()
        {
            return $"{RandomUtils.RandomDigits(3)}{RandomUtils.RandomDigits(3)}{RandomUtils.RandomDigits(4)}";
        }
    }
}

