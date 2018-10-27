using System;
using System.Linq;
using Xunit;

namespace Permutations
{
    public class PermutationsTest
    {
        [Fact]
        public void InsertionSortSortsArray()
        {
            var elementsCount = 3;
            var testCollection = Enumerable.Range(0, elementsCount).Select(e => e as IComparable).ToArray();

            var permutations = testCollection.GeneratePermutations();

            foreach(var permutation in permutations)
            {
                Console.WriteLine(String.Join(' ', permutation.Select(x => x.ToString())));
            }
            Assert.Equal(SimpleFactorial(elementsCount), permutations.Count);
        }

        private static int SimpleFactorial(int n)
        {
            return n <= 1 ? 1 : n * SimpleFactorial(--n);
        }
    }
}