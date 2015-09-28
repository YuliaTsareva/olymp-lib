using System;

namespace DataStructures
{
	public class MaxBinaryHeap<T> where T : IComparable<T>
	{
		private const int DEFAULT_CAPACITY = 4;

		private int _capacity;
		private T[] _items;

		public MaxBinaryHeap()
		{
			_capacity = 0;
			_items = new T[0];
		}

		public MaxBinaryHeap(int capacity)
		{
			_capacity = capacity;
			_items = new T[_capacity];
		}

		public int Count { get; private set; }

		public void Add(T item)
		{
			if (Count == _capacity)
			{
				IncreaseCapacity();
			}

			var index = Count;
			_items[index] = item;
			Count++;

			PushItemUp(index);
		}

		private void IncreaseCapacity()
		{
			var increasedCapacity = _capacity == 0 ? DEFAULT_CAPACITY : _capacity * 2;
			var extendedItems = new T[increasedCapacity];
			Array.Copy(_items, extendedItems, Count);

			_capacity = increasedCapacity;
			_items = extendedItems;
		}

		private void PushItemUp(int index)
		{
			var parent = GetParentIndex(index);
			while (index > 0 && _items[parent].CompareTo(_items[index]) < 0)
			{
				Swap(parent, index);
				index = parent;
				parent = GetParentIndex(index);
			}
		}

		private int GetParentIndex(int index)
		{
			return (index + 1) / 2 - 1;
		}

		private int GetLeftChildIndex(int index)
		{
			return (index + 1) * 2 - 1;
		}

		private int GetRightChildIndex(int index)
		{
			return (index + 1) * 2;
		}

		private void Swap(int index1, int index2)
		{
			var temp = _items[index1];
			_items[index1] = _items[index2];
			_items[index2] = temp;
		}

		public T DeleteMax()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Heap is empty");
			}

			Count--;
			var item = _items[0];
			_items[0] = _items[Count];
			_items[Count] = default(T);

			if (Count > 0)
			{
				PushItemDown(0);
			}

			return item;
		}

		public T PeekMax()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Heap is empty");
			}

			return _items[0];
		}

		private void PushItemDown(int index)
		{
			var childToSwapWith = GetChildIndexForSwap(index);

			while (childToSwapWith > 0)
			{
				Swap(index, childToSwapWith);

				index = childToSwapWith;
				childToSwapWith = GetChildIndexForSwap(index);
			}
		}

		private int GetChildIndexForSwap(int index)
		{
			var leftChildIndex = GetLeftChildIndex(index);

			if (Count <= leftChildIndex)
			{
				return -1; // no children
			}

			var leftChild = _items[leftChildIndex];

			var rightChildIndex = GetRightChildIndex(index);

			if (Count <= rightChildIndex)
			{
				// only left child
				return leftChild.CompareTo(_items[index]) > 0 ? leftChildIndex : -1;
			}

			var rightChild = _items[rightChildIndex];
			var maxIndex = leftChild.CompareTo(rightChild) >= 0 ? leftChildIndex : rightChildIndex;

			return _items[maxIndex].CompareTo(_items[index]) > 0 ? maxIndex : -1;
		}

		public T[] ToArray()
		{
			var array = new T[Count];
			Array.Copy(_items, array, Count);

			return array;
		}
	}
}