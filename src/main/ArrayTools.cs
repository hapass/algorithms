using System;
using System.Diagnostics;
using System.Linq;

namespace Tools
{
    public static class ArrayTools
    {
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

                if (array[currentItem].CompareTo(array[previousItem]) < 0)
                    return false;
            }

            return true;
        }
    }
}
