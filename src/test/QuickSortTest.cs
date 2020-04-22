using System;
using System.Linq;
using Xunit;
using Tools;

namespace Algorithms
{
    public class QuickSortTest
    {
        [Fact]
        public void QuickSortSortsArray()
        {
            var testCollection = TestData.GetUnsortedCharArray();
            Assert.True(testCollection.IsSorted());
            var algorithm = new QuickSort();
            algorithm.Sort(testCollection);
            Assert.True(testCollection.IsSorted());
        }
    }
}