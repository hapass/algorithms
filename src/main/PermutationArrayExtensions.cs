using System;
using System.Collections.Generic;
using System.Linq;
using Sorting;
using Tools;

namespace Permutations
{
    public static class PermutationArrayExtensions
    {
        public static List<T[]> GeneratePermutations<T>(this T[] array, int? length = null)
        {
            var permutationLength = length ?? array.Length;
            var permutations = new List<T[]>();
            var currentIndex = 0;

            if(array.Length == permutationLength)
            {
                permutations.Add(array.Copy());
            }

            while(true)
            {
                if(permutationLength > 2)
                {
                    permutations.AddRange(GeneratePermutations(array, permutationLength - 1));
                }

                if(currentIndex >= permutationLength - 1)
                {
                    break;
                }

                if(IsOdd(permutationLength))
                {
                    //array.Exchange(0, permutationLength - 1);
                }

                if(IsEven(permutationLength))
                {
                    //array.Exchange(currentIndex, permutationLength - 1);
                }

                permutations.Add(array.Copy());
                currentIndex++;
            }

            return permutations;
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private static bool IsOdd(int number)
        {
            return !IsEven(number);
        }
    }
}