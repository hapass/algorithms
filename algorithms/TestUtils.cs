using System;
using System.Linq;

namespace Algorithms
{
    public static class TestUtils
    {
        public static bool IsSorted(IComparable[] array)
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

        public static bool AreEqual(IComparable[] first, IComparable[] second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            Array.Sort(first);
            Array.Sort(second);

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static IComparable[] GetUnsortedCharArray()
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