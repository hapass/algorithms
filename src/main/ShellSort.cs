using System;

namespace Sorting
{
    public class ShellSort
    {
        public enum Sequence
        {
            Simple
        }

        private Sequence type;

        public ShellSort(Sequence type)
        {
            this.type = type;
        }

        public ShellSort(): this(Sequence.Simple) { }

        public void Sort(IComparable[] array)
        {
            var intervalSequence = GetIntervalSequence(array);
            int interval;
            do
            {
                interval = intervalSequence.PopInterval();
                for (var index = interval; index < array.Length; index++)
                {
                    var currentElementIndex = index;
                    var previousElementIndex = currentElementIndex - interval;
                    while (previousElementIndex >= 0 && array[currentElementIndex].CompareTo(array[previousElementIndex]) < 0)
                    {
                        //array.Exchange(currentElementIndex, previousElementIndex);
                        currentElementIndex -= interval;
                        previousElementIndex -= interval;
                    }
                }
            }
            while (interval != 1);
        }

        protected virtual IShellSortSequence GetIntervalSequence(IComparable[] array)
        {
            switch (type)
            {
                case Sequence.Simple:
                    return new SimpleShellSortSequence(array);
                default:
                    throw new NotSupportedException("This sequence is not supported: " + type);
            }
        }

        protected interface IShellSortSequence
        {
            int PopInterval();
        }

        private class SimpleShellSortSequence : IShellSortSequence
        {
            private int largestInterval;
            private int arrayLength;
            
            public SimpleShellSortSequence(IComparable[] array)
            {
                this.largestInterval = 1;
                this.arrayLength = array.Length;
                ComputeLargestSequenceInterval();
            }

            private void ComputeLargestSequenceInterval()
            {
                while (largestInterval < arrayLength)
                {
                    largestInterval = 3 * largestInterval + 1;
                }
            }

            public int PopInterval()
            {
                var nextInterval = largestInterval;
                largestInterval /= 3;
                return nextInterval;
            }
        }
    }
}
