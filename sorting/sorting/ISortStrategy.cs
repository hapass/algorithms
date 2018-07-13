using System;
namespace sorting
{
	public interface ISortStrategy
	{
		void Sort(IComparable[] array);
	}
}
