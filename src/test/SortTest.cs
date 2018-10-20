using System;
using System.Linq;
using Sorting;
using Xunit;

namespace Test
{
    public class SortTest
    {
        [Fact]
        public void InsertionSortSortsArray()
        {
            var testCollection = GetTestCharArray();

            testCollection.Sort(new InsertionSort());

            Assert.True(testCollection.IsSorted());
        }

        [Fact]
        public void SelectionSortSortsArray()
        {
            var testCollection = GetTestCharArray();

            testCollection.Sort(new SelectionSort());

            Assert.True(testCollection.IsSorted());
        }

        [Fact]
        public void ShellSortSortsArray()
        {
            var testCollection = GetTestCharArray();

            testCollection.Sort(new ShellSort());

            Assert.True(testCollection.IsSorted());
        }

        private static IComparable[] GetTestCharArray()
        {
            return "QUITEEXCELLENTSORTTESTWITHOUTREPEATINGLETTERS"
                .ToCharArray()
                .Distinct()
                .Select(e => e as IComparable)
                .Where(e => e != null)
                .ToArray();
        }
    }
}
