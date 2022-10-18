using System;
using ScamTroller.Extensions;

namespace ScamTroller.Utils
{
    public static class CreditCardGenerator
    {
        private static Random Random = new Random();

        static Dictionary<string, bool> Numbers = new Dictionary<string, bool>();

        static List<string> ValidNumbers = new List<string>();
        static List<string> UsedValidNumbers = new List<string>();

        public static bool LuhnValidation(string value)
        {
            int total = 0;
            for(int i = 0; i < value.Length; i++)
            {
                int num = int.Parse(value.Substring(i, 1));
                total += i % 2 == 0 ? X2Minus9(num) : num;
            }
            return total % 10 == 0;
        }

        static int X2Minus9(int value)
        {
            return (value *= 2) > 9 ? value - 9 : value;
        }

        public static void Cook(int sampleSize)
        {
            string value;
            for(int i = 0; i < sampleSize; i++)
            {
                do
                {
                    value = GenerateRandomCreditCard();
                } while (!LuhnValidation(value));
                Numbers[value] = true;
                ValidNumbers.Add(value);
            }
        }

        static string GenerateRandomCreditCard() => $"4{RandomUtils.RandomDigits(15)}";

        public static (string Number, string ExpMonth, string ExpYear, string CVV) GenerateCreditCard()
        {
            string creditCardNumber = ValidNumbers.SelectRandomUnused(UsedValidNumbers);
            return (creditCardNumber, Random.Next(13).ToString("00"), Random.Next(23, 27).ToString(), RandomUtils.RandomDigits(3));
        }
    }
}

