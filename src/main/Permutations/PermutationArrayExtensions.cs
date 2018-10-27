using System;
using System.Collections.Generic;
using System.Linq;
using Sorting;

namespace Permutations
{
    public static class PermutationArrayExtensions
    {
        public static List<IComparable[]> GeneratePermutations(this IComparable[] array, int? length = null)
        {
            var permutationLength = length ?? array.Length;
            var permutations = new List<IComparable[]>();
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
                    array.Exchange(0, permutationLength - 1);
                }

                if(IsEven(permutationLength))
                {
                    array.Exchange(currentIndex, permutationLength - 1);
                }

                permutations.Add(array.Copy());
                currentIndex++;
            }

            return permutations;
        }

        private static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        private static bool IsOdd(int n)
        {
            return !IsEven(n);
        }
    }
}