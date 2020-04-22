using System;

namespace Algorithms
{
    public class BinaryHeap
    {
        private IComparable[] heap = new IComparable[1];
        int elementCount = 0;

        public void Push(IComparable item)
        {
            elementCount++;

            //resize if needed
            if (heap.Length < elementCount)
            {
                IComparable[] resizedHeap = new IComparable[heap.Length * 2];
                heap.CopyTo(resizedHeap, 0);
                heap = resizedHeap;
            }

            Console.WriteLine("Element index: " + (elementCount - 1));
            Console.WriteLine("Element count: " + elementCount);
            Console.WriteLine("Heap size: " + heap.Length);
            heap[elementCount - 1] = item;
            Swim(elementCount - 1);
        }

        private void Swim(int elementIndex)
        {
            if (elementIndex == 0)
            {
                return;
            }

            int parentIndex = (elementIndex + 1) / 2 - 1;
            
            //min at the top
            if (heap[elementIndex].CompareTo(heap[parentIndex]) < 0)
            {
                var tempElement = heap[elementIndex];
                heap[elementIndex] = heap[parentIndex];
                heap[parentIndex] = tempElement;
                Swim(parentIndex);
            }
        }

        public IComparable Pop()
        {
            if (elementCount == 0)
            {
                return null;
            }

            IComparable poppedItem = heap[0];

            for (int i = 1; i < elementCount; i++)
            {
                heap[i - 1] = heap[i];
            }

            heap[elementCount - 1] = null;
            elementCount--;

            Sink(0);

            return poppedItem;
        }

        private void Sink(int elementIndex)
        {
            int leftElementIndex = elementIndex + 1;
            int rightElementIndex = elementIndex + 2;

            if (leftElementIndex < elementCount && heap[elementIndex].CompareTo(heap[leftElementIndex]) > 0)
            {
                IComparable tempElement = heap[elementIndex];
                heap[elementIndex] = heap[leftElementIndex];
                heap[leftElementIndex] = heap[elementIndex];
                Sink(leftElementIndex);
            }

            if (rightElementIndex < elementCount && heap[elementIndex].CompareTo(heap[rightElementIndex]) > 0)
            {
                IComparable tempElement = heap[elementIndex];
                heap[elementIndex] = heap[rightElementIndex];
                heap[rightElementIndex] = heap[elementIndex];
                Sink(rightElementIndex);
            }
        }
    }
}