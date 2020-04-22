using System;

namespace Algorithms
{
    public class MergeSort
    {
        //do not allocate arrays all the time!
        public IComparable[] Sort(IComparable[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            IComparable[] first = new IComparable[array.Length / 2];
            IComparable[] second = new IComparable[array.Length - first.Length];

            for (int i = 0; i < first.Length; i++)
            {
                first[i] = array[i];
            }

            for (int i = 0; i < second.Length; i++)
            {
                second[i] = array[first.Length + i];
            }

            first = Sort(first);
            second = Sort(second);

            IComparable[] merged = new IComparable[array.Length];

            int firstI = 0;
            int secondI = 0;

            for (int i = 0; i < merged.Length; i++)
            {
                if (firstI >= first.Length)
                {
                    merged[i] = second[secondI];
                    secondI++;
                    continue;
                }

                if (secondI >= second.Length)
                {
                    merged[i] = first[firstI];
                    firstI++;
                    continue;
                }

                if (first[firstI].CompareTo(second[secondI]) < 0)
                {
                    merged[i] = first[firstI];
                    firstI++;
                }
                else
                {
                    merged[i] = second[secondI];
                    secondI++;
                }
            }

            return merged;
         }
    }
}