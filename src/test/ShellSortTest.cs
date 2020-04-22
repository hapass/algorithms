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
            var testCollection = TestData.GetUnsortedCharArray();
            var algorithm = new ShellSort();
            algorithm.Sort(testCollection);
            Assert.True(testCollection.IsSorted());
        }
    }
}