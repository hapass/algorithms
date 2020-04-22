using System;

namespace Algorithms
{
    public class ShellSort
    {
        public void Sort(IComparable[] array)
        {
            int step = 1;
            while (step < array.Length / 3)
            {
                step = step * 3 + 1;
            }

            while (step >= 1)
            {
                InsertionSort(array, step);
                step = step / 3;
            }
        }

        private void InsertionSort(IComparable[] array, int step)
        {
            for (int i = step; i < array.Length; i++)
            {
                for (int j = i; j >= step; j -= step)
                {
                    if (array[j - step].CompareTo(array[j]) > 0)
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
