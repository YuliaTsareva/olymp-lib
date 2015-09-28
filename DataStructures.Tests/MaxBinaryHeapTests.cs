using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace DataStructures.Tests
{
	[TestClass]
	public class MaxBinaryHeapTests
	{
		#region constructors

		[TestMethod]
		public void Create_ExpectCountToBeZero()
		{
			var heap = new MaxBinaryHeap<int>();

			Assert.AreEqual(0, heap.Count);
		}

		#endregion

		#region Add

		[TestMethod]
		public void Add_ExpectCountIncrement()
		{
			var heap = new MaxBinaryHeap<int>();

			heap.Add(10);

			Assert.AreEqual(1, heap.Count);
		}

		[TestMethod]
		public void Add_ExpectHeapContainsItem()
		{
			var heap = new MaxBinaryHeap<int>();
			var item = 10;

			heap.Add(item);

			CollectionAssert.AreEquivalent(new[] { item }, heap.ToArray());
		}

		[TestMethod]
		public void Add_SecondAddedItemIsGreater_ExpectGreaterItemIsMovedToArrayBeginning()
		{
			var heap = new MaxBinaryHeap<int>();

			heap.Add(10);
			heap.Add(15);

			CollectionAssert.AreEqual(new[] { 15, 10 }, heap.ToArray());
		}

		[TestMethod]
		public void Add_MoreThanOneSwap_ExpectMaxItemIsMovedToArrayBeginning()
		{
			var heap = new MaxBinaryHeap<int>();

			heap.Add(1);
			heap.Add(3);
			heap.Add(5);
			heap.Add(8);

			CollectionAssert.AreEqual(new[] { 8, 5, 3, 1 }, heap.ToArray());
		}

		#endregion

		#region DeleteMax

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void DeleteMax_EmptyHeap_ExpectThrowInvalidOperationException()
		{
			var heap = new MaxBinaryHeap<int>();

			heap.DeleteMax();
		}

		[TestMethod]
		public void DeleteMax_OneItem_ExpectCountDecrement()
		{
			var heap = new MaxBinaryHeap<int>();
			heap.Add(10);

			heap.DeleteMax();

			Assert.AreEqual(0, heap.Count);
		}

		[TestMethod]
		public void DeleteMax_OneItem_ExpectReturnItem()
		{
			var heap = new MaxBinaryHeap<int>();
			heap.Add(10);

			var max = heap.DeleteMax();

			Assert.AreEqual(10, max);
		}

		[TestMethod]
		public void DeleteMax_TwoNotEqualItems_ExpectCountDecrement()
		{
			var heap = new MaxBinaryHeap<int>();
			heap.Add(10);
			heap.Add(20);

			heap.DeleteMax();

			Assert.AreEqual(1, heap.Count);
		}

		[TestMethod]
		public void DeleteMax_TwoNotEqualItems_ExpectReturnMax()
		{
			var heap = new MaxBinaryHeap<int>();
			heap.Add(10);
			heap.Add(20);

			var max = heap.DeleteMax();

			Assert.AreEqual(20, max);

			heap = new MaxBinaryHeap<int>();
			heap.Add(20);
			heap.Add(10);

			max = heap.DeleteMax();

			Assert.AreEqual(20, max);
		}

		[TestMethod]
		public void DeleteMax_MoreThanOneSwap_ExpectHeapIsValid()
		{
			var heap = new MaxBinaryHeap<int>();

			//three complete layers in tree + one element on the forth layer
			var items = new[] { 1, 3, 5, 8, 13, 21, 34, 55 };
			foreach (var item in items)
			{
				heap.Add(item);
			}

			heap.DeleteMax();

			var expectedArray = new[] { 34, 8, 21, 1, 5, 3, 13 };
			CollectionAssert.AreEqual(expectedArray, heap.ToArray());
		}

		#endregion

		#region PeekMax

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void PeekMax_EmptyHeap_ExpectThrowInvalidOperationException()
		{
			var heap = new MaxBinaryHeap<int>();

			heap.PeekMax();
		}

		[TestMethod]
		public void PeekMax_OneItem_ExpectReturnItem()
		{
			var heap = new MaxBinaryHeap<int>();
			heap.Add(10);

			var peekedItem = heap.PeekMax();

			Assert.AreEqual(10, peekedItem);
		}

		[TestMethod]
		public void PeekMax_ExpectCountNotChange()
		{
			var heap = new MaxBinaryHeap<int>();
			heap.Add(10);

			heap.PeekMax();

			Assert.AreEqual(1, heap.Count);
		}

		#endregion
	}
}