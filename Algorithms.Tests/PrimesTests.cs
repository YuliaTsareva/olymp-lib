using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace Algorithms.Tests
{
	[TestClass]
	public class PrimesTests
	{
		#region IsPrime

		[TestMethod]
		public void IsPrime_Zero_ExpectFalse()
		{
			var result = Primes.IsPrime(0);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void IsPrime_One_ExpectFalse()
		{
			var result = Primes.IsPrime(1);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void IsPrime_Two_ExpectTrue()
		{
			var result = Primes.IsPrime(2);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void IsPrime_BigNotPrimeNumber_ExpectFalse()
		{
			//99400891 = 9973 * 9967
			var result = Primes.IsPrime(99400891);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void IsPrime_BigPrimeNumber_ExpectTrue()
		{
			var result = Primes.IsPrime(15485867);
			Assert.IsTrue(result);
		}

		#endregion IsPrime

		#region GetPrimes

		[TestMethod]
		public void GetPrimes_LessOrEqualOne_ExpectListIsEmpty()
		{
			var result = Primes.GetPrimes(1);
			CollectionAssert.AreEqual(new int[0], result);
		}

		[TestMethod]
		public void GetPrimes_LessOrEqualTwo_ExpectListContainsOneNumber()
		{
			var result = Primes.GetPrimes(2);
			CollectionAssert.AreEqual(new[] {2}, result);
		}

		[TestMethod]
		public void GetPrimes_LessOrEqualTwenty_ExpectListContainsEightNumbers()
		{
			var result = Primes.GetPrimes(20);
			CollectionAssert.AreEqual(new[] {2, 3, 5, 7, 11, 13, 17, 19}, result);
		}

		[TestMethod]
		public void GetPrimes_LessOrEqual10000_ExpectListContains1229Numbers()
		{
			var result = Primes.GetPrimes(10000);
			Assert.AreEqual(1229, result.Length);
		}

		#endregion GetPrimes
	}
}