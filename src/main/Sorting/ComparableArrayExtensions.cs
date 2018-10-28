using System;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{
    public static class ComparableArrayExtensions
    {
        public static void Sort(this IComparable[] array, ISortStrategy strategy)
        {
            strategy.Sort(array);
        }

        public static bool IsLessThan(this IComparable item, IComparable anotherItem)
        {
            return item.CompareTo(anotherItem) < 0;
        }

        public static void Exchange<T>(this T[] array, int firstItemIndex, int secondItemIndex)
        {
            AssertInsideArray(array, firstItemIndex, nameof(firstItemIndex));
            AssertInsideArray(array, secondItemIndex, nameof(secondItemIndex));

            var firstItem = array[firstItemIndex];
            array[firstItemIndex] = array[secondItemIndex];
            array[secondItemIndex] = firstItem;
        }

        private static void AssertInsideArray<T>(T[] array, int index, string name)
        {
            Debug.Assert(0 <= index && index < array.Length, $"Assertion failed: index {name} is outside the array bounds.");
        }

        public static T[] Copy<T>(this T[] array)
        {
            return array.Select(x => x).ToArray();
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
