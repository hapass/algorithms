using System;

namespace Sorting
{
    public interface ISortStrategy
    {
        void Sort(IComparable[] array);
    }
}
