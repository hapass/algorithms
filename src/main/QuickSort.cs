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
            StringBuilder builder = new StringBuilder();
            foreach (Object item in array)
            {
                builder.Append(item.ToString());
                builder.Append(",");
            }
            Console.WriteLine(builder.ToString());

            if (from == to)
            {
                return;
            }

            int pivot = 0;

            int i = from;
            int j = to;

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