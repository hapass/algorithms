using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class BubbleSortTest
    {
        [Fact]
        public void BubbleSortSortsArray()
        {
            var testCollection = TestUtils.GetUnsortedCharArray();
            var algorithm = new BubbleSort();
            algorithm.Sort(testCollection);
            Assert.True(TestUtils.IsSorted(testCollection));
        }
    }
}