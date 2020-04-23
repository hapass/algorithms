using System;
using System.Linq;
using Xunit;

namespace Algorithms
{
    public class BinaryHeapTest
    {
        [Fact]
        public void BinaryHeapSortsArray()
        {
            var testCollection = TestUtils.GetUnsortedCharArray();
            var heap = new BinaryHeap();

            for (int i = 0; i < testCollection.Length; i++)
            {
                heap.Push(testCollection[i]);
            }

            IComparable[] result = new IComparable[testCollection.Length];
            for (int i = 0; i < testCollection.Length; i++)
            {
                result[i] = heap.Pop();
                Console.WriteLine(result[i]);
            }

            Assert.True(TestUtils.IsSorted(result));
            Assert.True(TestUtils.AreEqual(testCollection, result));
        }
    }
}