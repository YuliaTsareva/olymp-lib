using System;

namespace DataStructures
{
	public class MaxPriorityQueue<T> where T : IComparable<T>
	{
		private readonly MaxBinaryHeap<T> _heap = new MaxBinaryHeap<T>();

		public int Count
		{
			get { return _heap.Count; }
		}

		public void Add(T item)
		{
			_heap.Add(item);
		}

		public T DequeueMax()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			return _heap.DeleteMax();
		}

		public T PeekMax()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			return _heap.PeekMax();
		}

		public T[] ToArray()
		{
			return _heap.ToArray();
		}

		public override string ToString()
		{
			return string.Format("{{ {0} }}", string.Join(",", _heap.ToArray()));
		}
	}
}