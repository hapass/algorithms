using System;
namespace sorting
{
	public class InsertionSort : ISortStrategy
	{
		public void Sort(IComparable[] array)
		{
			const int secondElementIndex = 1;
			for (var index = secondElementIndex; index < array.Length; index++)
			{
				var currentElementIndex = index;
				var previousElementIndex = currentElementIndex - 1;
				while (previousElementIndex >= 0 && array[currentElementIndex].IsLessThan(array[previousElementIndex]))
				{
					array.Exchange(currentElementIndex, previousElementIndex);
					currentElementIndex--;
					previousElementIndex--;
				}
			}
		}

	}
}
