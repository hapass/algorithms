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

            heap[0] = heap[elementCount - 1];
            heap[elementCount - 1] = null;
            elementCount--;

            Sink(0);

            return poppedItem;
        }

        private void Sink(int elementIndex)
        {
            int leftElementIndex = 2 * elementIndex + 1;
            int rightElementIndex = 2 * elementIndex + 2;

            if (leftElementIndex >= elementCount)
            {
                return;
            }

            if (rightElementIndex >= elementCount)
            {
                if (heap[elementIndex].CompareTo(heap[leftElementIndex]) > 0)
                {
                    IComparable tempElement = heap[elementIndex];
                    heap[elementIndex] = heap[leftElementIndex];
                    heap[leftElementIndex] = tempElement;
                }
                return;
            }

            if (heap[leftElementIndex].CompareTo(heap[rightElementIndex]) <= 0)
            {
                if (heap[elementIndex].CompareTo(heap[leftElementIndex]) > 0)
                {
                    IComparable tempElement = heap[elementIndex];
                    heap[elementIndex] = heap[leftElementIndex];
                    heap[leftElementIndex] = tempElement;
                    Sink(leftElementIndex);
                }
            }
            else
            {
                if (heap[elementIndex].CompareTo(heap[rightElementIndex]) > 0)
                {
                    IComparable tempElement = heap[elementIndex];
                    heap[elementIndex] = heap[rightElementIndex];
                    heap[rightElementIndex] = tempElement;
                    Sink(rightElementIndex);
                }
            }
        }
    }
}