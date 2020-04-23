using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class InsertionSortTest
    {
        [Fact]
        public void InsertionSortSortsArray()
        {
            var testCollection = TestUtils.GetUnsortedCharArray();
            var algorithm = new ShellSort();
            algorithm.Sort(testCollection);
            Assert.True(TestUtils.IsSorted(testCollection));
        }
    }
}