using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class ShellSortTest
    {
        [Fact]
        public void ShellSortSortsArray()
        {
            var testCollection = TestUtils.GetUnsortedCharArray();
            var algorithm = new ShellSort();
            algorithm.Sort(testCollection);
            Assert.True(TestUtils.IsSorted(testCollection));
        }
    }
}