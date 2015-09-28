using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace DataStructures.Tests
{
	[TestClass]
	public class PriorityQueueTests
	{
		private const int ITEM = 15;
		private const int MIN_ITEM = 10;
		private const int MAX_ITEM = 20;

		#region constructors

		[TestMethod]
		public void Create_ExpectCountToBeZero()
		{
			var queue = new MaxPriorityQueue<int>();
			Assert.AreEqual(0, queue.Count);
		}

		#endregion

		#region common

		private MaxPriorityQueue<int> CreateQueueAddTwoNotEqualItems()
		{
			var queue = new MaxPriorityQueue<int>();
			queue.Add(MIN_ITEM);
			queue.Add(MAX_ITEM);
			return queue;
		}

		#endregion

		#region Add

		[TestMethod]
		public void Add_ExpectCountIncrement()
		{
			var queue = new MaxPriorityQueue<int>();

			queue.Add(ITEM);

			Assert.AreEqual(1, queue.Count);
		}

		[TestMethod]
		public void Add_ExpectQueueContainsItem()
		{
			var queue = new MaxPriorityQueue<int>();

			queue.Add(ITEM);

			var items = queue.ToArray();
			CollectionAssert.AreEquivalent(new[] { ITEM }, items);
		}

		#endregion

		#region DequeueMax

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void DequeueMax_EmptyQueue_ExpectThrowInvalidOperationException()
		{
			var queue = new MaxPriorityQueue<int>();

			queue.DequeueMax();
		}

		[TestMethod]
		public void DequeueMax_OneItem_ExpectCountDecrement()
		{
			var queue = new MaxPriorityQueue<int>();
			queue.Add(ITEM);

			queue.DequeueMax();

			Assert.AreEqual(0, queue.Count);
		}

		[TestMethod]
		public void DequeueMax_OneItem_ExpectReturnItem()
		{
			var queue = new MaxPriorityQueue<int>();
			queue.Add(ITEM);

			var dequeuedItem = queue.DequeueMax();

			Assert.AreEqual(ITEM, dequeuedItem);
		}

		[TestMethod]
		public void DequeueMax_TwoNotEqualItems_ExpectReturnMax()
		{
			var queue = CreateQueueAddTwoNotEqualItems();
			queue.Add(MIN_ITEM);
			queue.Add(MAX_ITEM);

			var dequeuedItem = queue.DequeueMax();
			Assert.AreEqual(MAX_ITEM, dequeuedItem);

			//check order of insertion does not matter
			queue = new MaxPriorityQueue<int>();
			queue.Add(MAX_ITEM);
			queue.Add(MIN_ITEM);

			dequeuedItem = queue.DequeueMax();
			Assert.AreEqual(MAX_ITEM, dequeuedItem);
		}

		[TestMethod]
		public void DequeueMax_TwoNotEqualItems_ExpectCountDecrement()
		{
			var queue = CreateQueueAddTwoNotEqualItems();

			queue.DequeueMax();
			Assert.AreEqual(1, queue.Count);
		}

		[TestMethod]
		public void DequeueMax_TwoNotEqualItems_ExpectMinItemToBeInQueue()
		{
			var queue = CreateQueueAddTwoNotEqualItems();

			queue.DequeueMax();
			CollectionAssert.AreEquivalent(new[] { MIN_ITEM }, queue.ToArray());
		}

		#endregion

		#region PeekMax

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void PeekMax_EmptyQueue_ExpectThrowInvalidOperationException()
		{
			var queue = new MaxPriorityQueue<int>();

			queue.PeekMax();
		}

		[TestMethod]
		public void PeekMax_OneItem_ExpectReturnItem()
		{
			var queue = new MaxPriorityQueue<int>();
			queue.Add(ITEM);

			var peekedItem = queue.PeekMax();

			Assert.AreEqual(ITEM, peekedItem);
		}

		[TestMethod]
		public void PeekMax_ExpectCountNotChange()
		{
			var queue = new MaxPriorityQueue<int>();
			queue.Add(ITEM);

			queue.PeekMax();

			Assert.AreEqual(1, queue.Count);
		}

		[Ignore]
		[TestMethod]
		public void UltimateTest()
		{
			const int COUNT = 100000;

			var random = new Random();

			var array = new int[COUNT];
			var queue = new MaxPriorityQueue<int>();

			for (var i = 0; i < COUNT; i++)
			{
				array[i] = random.Next(COUNT);
				queue.Add(array[i]);
			}

			Array.Sort(array);
			Array.Reverse(array);

			var numbersFromQueue = new int[COUNT];
			for (var i = 0; i < COUNT; i++)
			{
				numbersFromQueue[i] = queue.DequeueMax();
			}

			Assert.AreEqual(0, queue.Count);
			CollectionAssert.AreEqual(array, numbersFromQueue);
		}
		#endregion
	}
}