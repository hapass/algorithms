using System;

namespace Algorithms
{
    public class BubbleSort
    {
        public void Sort(IComparable[] array)
        {
            bool isAnySwapped;
            int n = array.Length - 1;
            do
            {
                isAnySwapped = false;
                for (int j = 0; j < n; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        isAnySwapped = true;
                    }
                }
                n--;
            } while (isAnySwapped);
        }
    }
}