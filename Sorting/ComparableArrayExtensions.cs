using System;
using System.Diagnostics;

namespace Sorting
{
    public static class ComparableArrayExtensions
    {
        private const string ElementDelimiter = " ";

        public static void Sort(this IComparable[] array, ISortStrategy strategy)
        {
            strategy.Sort(array);
        }

        public static bool IsLessThan(this IComparable item, IComparable anotherItem)
        {
            return item.CompareTo(anotherItem) < 0;
        }

        public static void Exchange(this IComparable[] array, int firstItemIndex, int secondItemIndex)
        {
            AssertInsideArray(array, firstItemIndex, nameof(firstItemIndex));
            AssertInsideArray(array, secondItemIndex, nameof(secondItemIndex));

            var firstItem = array[firstItemIndex];
            array[firstItemIndex] = array[secondItemIndex];
            array[secondItemIndex] = firstItem;
        }

        private static void AssertInsideArray(IComparable[] array, int index, string name)
        {
            Debug.Assert(0 <= index && index < array.Length, $"Assertion failed: index {name} is outside the array bounds.");
        }

        public static void Print(this IComparable[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + ElementDelimiter);
            }
            Console.WriteLine();
        }

        public static bool IsSorted(this IComparable[] array)
        {
            const int SecondItemIndex = 1;
            for (int index = SecondItemIndex; index < array.Length; index++)
            {
                var currentItem = index;
                var previousItem = index - 1;

                if (currentItem.IsLessThan(previousItem))
                    return false;
            }

            return true;
        }
    }
}
