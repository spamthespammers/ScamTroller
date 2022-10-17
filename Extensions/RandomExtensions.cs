using System;
namespace ScamTroller.Extensions
{
    public static class RandomExtensions
    {
        public static Random Random = new Random();
        public static T SelectRandom<T>(this IEnumerable<T> collection)
        {
            return collection.ElementAt(Random.Next(collection.Count()));
        }

        public static T SelectRandomUnused<T>(this IEnumerable<T> setA, IEnumerable<T> setB)
        {
            IEnumerable<T> unused = setA.Except(setB);
            if(unused.Count() == 0)
            {
                return default(T);
            }

            return unused.SelectRandom();
        }

    }
}

