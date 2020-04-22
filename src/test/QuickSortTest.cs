using System;
using System.Linq;
using Xunit;
using Tools;

namespace Algorithms
{
    public class QuickSortTest
    {
        [Fact]
        public void MergeSortSortsArray()
        {
            var testCollection = TestData.GetUnsortedCharArray();
            var algorithm = new QuickSort();
            algorithm.Sort(testCollection);
            Assert.True(testCollection.IsSorted());
        }
    }
}