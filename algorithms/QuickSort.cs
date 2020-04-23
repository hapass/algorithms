using System;
using System.Text;

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

            int pivot = from;
            int i = from;
            int j = to;

            while(true)
            {
                while (array[i].CompareTo(array[pivot]) < 0 && i <= to)
                {
                    i++;
                }

                while(array[j].CompareTo(array[pivot]) > 0 && j >= from)
                {
                    j--;
                }

                if (i >= j)
                {
                    IComparable pivotTemp = array[pivot];
                    array[pivot] = array[i];
                    array[i] = pivotTemp;
                    break;
                }
                else
                {
                    IComparable iTemp = array[i];
                    array[i] = array[j];
                    array[j] = iTemp;
                }
            }

            SortInternal(array, from, i);
            SortInternal(array, i + 1, to);
        }
    }
}