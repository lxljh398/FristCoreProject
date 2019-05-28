using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> listArray = new List<List<string>>()
            {
                new List<string>() { "M","L","X" },
                new List<string>() { "红色","蓝色" },
                new List<string>() { "标准","加厚" },
            };

            var allCombinations = AllCombinationsOf(listArray);
            foreach (var combination in allCombinations)
            {
                Console.WriteLine(string.Join(", ", combination));
            }

            Console.ReadLine();
        }

        public static List<List<T>> AllCombinationsOf<T>(List<List<T>> sets)
        {
            var combinations = new List<List<T>>();

            foreach (var value in sets[0])
                combinations.Add(new List<T> { value });

            foreach (var set in sets.Skip(1))
                combinations = AddExtraSet(combinations, set);

            return combinations;
        }

        private static List<List<T>> AddExtraSet<T>(List<List<T>> combinations, List<T> set)
        {
            var newCombinations = from value in set
                                  from combination in combinations
                                  select new List<T>(combination) { value };

            return newCombinations.ToList();
        }
    }
}
