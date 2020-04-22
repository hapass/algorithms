using System;

namespace Algorithms
{
    public class InsertionSort
    {
        public void Sort(IComparable[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        IComparable temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
