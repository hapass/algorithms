using System;
using System.Linq;
using Xunit;
using Tools;

namespace Algorithms
{
    public class InsertionSortTest
    {
        [Fact]
        public void InsertionSortSortsArray()
        {
            var testCollection = GetTestCharArray();
            var algorithm = new InsertionSort();
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