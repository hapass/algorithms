using System;
using System.Linq;
using Xunit;
using Tools;

namespace Algorithms
{
    public class MergeSortTest
    {
        [Fact]
        public void MergeSortSortsArray()
        {
            var testCollection = TestData.GetUnsortedCharArray();
            var algorithm = new MergeSort();
            testCollection = algorithm.Sort(testCollection);
            Assert.True(testCollection.IsSorted());
        }
    }
}