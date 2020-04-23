using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class QuickSortTest
    {
        [Fact]
        public void QuickSortSortsArray()
        {
            var testCollection = TestUtils.GetUnsortedCharArray();
            var algorithm = new QuickSort();
            algorithm.Sort(testCollection);
            Assert.True(TestUtils.IsSorted(testCollection));
        }
    }
}