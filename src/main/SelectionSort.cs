using System;

namespace Sorting
{
    public class SelectionSort : ISortStrategy
    {
        public void Sort(IComparable[] array)
        {
            const int FirstIndex = 0;
            var lastIndex = array.Length - 1;
            for (var index = FirstIndex; index < lastIndex; index++)
            {
                //array.Exchange(index, FindMinInInterval(array, index, lastIndex));
            }
        }

        private int FindMinInInterval(IComparable[] array, int fromIndex, int toIndex)
        {
            var minValueIndex = fromIndex;
            var secondIndex = fromIndex + 1;
            for (var index = secondIndex; index <= toIndex; index++)
            {
                var currentValue = array[index];
                var currentMinValue = array[minValueIndex];
                if (currentValue.CompareTo(currentMinValue) < 0)
                {
                    minValueIndex = index;
                }
            }

            return minValueIndex;
        }
    }
}
