using System;

namespace Algorithms
{
    public class QuickSort
    {
        public void Sort(IComparable[] array)
        {
            SortInternal(array, 0, array.Length - 1);
        }

        public void SortInternal(IComparable[] array, int from, int to)
        {
            if (from == to)
            {
                return;
            }

            int pivot = 0;

            int i = 0;
            int j = array.Length - 1;

            while (array[i].CompareTo(array[pivot]) < 0)
            {
                i++;
            }

            while(array[j].CompareTo(array[pivot]) > 0)
            {
                j--;
            }

            if (i == j)
            {
                IComparable pivotTemp = array[pivot];
                array[pivot] = array[i];
                array[i] = pivotTemp;

                SortInternal(array, from, i);
                SortInternal(array, i + 1, to);
                return;
            }
            else
            {
                IComparable iTemp = array[i];
                array[i] = array[j];
                array[j] = iTemp;
            }
        }
    }
}