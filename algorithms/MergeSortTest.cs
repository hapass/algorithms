using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class MergeSortTest
    {
        [Fact]
        public void MergeSortSortsArray()
        {
            var testCollection = TestUtils.GetUnsortedCharArray();
            var algorithm = new MergeSort();
            testCollection = algorithm.Sort(testCollection);
            Assert.True(TestUtils.IsSorted(testCollection));
        }
    }
}