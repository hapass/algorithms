using System;
using System.Linq;
using Xunit;
using Tools;

namespace Algorithms
{
    public class BubbleSortTest
    {
        [Fact]
        public void BubbleSortSortsArray()
        {
            var testCollection = GetTestCharArray();
            var algorithm = new BubbleSort();
            algorithm.Sort(testCollection);
            Assert.True(testCollection.IsSorted());
        }

        private static IComparable[] GetTestCharArray()
        {
            return "QUITEEXCELLENTSORTTESTWITHOUTREPEATINGLETTERS"
                .ToCharArray()
                .Distinct()
                .Select(e => e as IComparable)
                .Where(e => e != null)
                .ToArray();
        }
    }
}