﻿using System;
using System.Text;
using ScamTroller.Extensions;

namespace ScamTroller.Utils
{
    public static class RandomUtils
    {

        static Random Random = new Random();


        public static string RandomDigits(int length)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                builder.Append(Random.Next(0, 10));
            }
            return builder.ToString();
        }

        public static string RandomLettersUpper(int length) => RandomLettersInRange('A', 'Z', length);
        public static string RandomLettersLower(int length) => RandomLettersInRange('a', 'z', length);



        private static string RandomLettersInRange(char start, char end, int length)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append((char)Random.Next((int)start), ((int)end) + 1);
            }
            return builder.ToString();
        }

    }
}

