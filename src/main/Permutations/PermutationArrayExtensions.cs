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

            if(permutationLength == array.Length)
            {
                permutations.Add(array);
            }

            while(currentIndex < permutationLength)
            {
                if(permutationLength >= 2) 
                {
                    permutations.AddRange(GeneratePermutations(array, --permutationLength));
                }

                if(IsOdd(permutationLength))
                {
                    array.Exchange(0, array.LastElementIndex());
                }

                if(IsEven(permutationLength))
                {
                    array.Exchange(currentIndex, array.LastElementIndex());
                }

                permutations.Add(array.Select(x => x).ToArray());
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