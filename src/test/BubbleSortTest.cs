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
            var testCollection = TestData.GetUnsortedCharArray();
            var algorithm = new BubbleSort();
            algorithm.Sort(testCollection);
            Assert.True(testCollection.IsSorted());
        }
    }
}