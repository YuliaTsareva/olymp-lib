using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace Algorithms.Tests.MathUtils
{
	[TestClass]
	public class GCDTests
	{
		[TestMethod]
		public void GetGCD_OneNumberEqualsZero_ExpectReturnAnother()
		{
			var gcd = Algorithms.MathUtils.GetGCD(5, 0);
			Assert.AreEqual(5, gcd);

			gcd = Algorithms.MathUtils.GetGCD(0, 5);
			Assert.AreEqual(5, gcd);
		}

		[TestMethod]
		public void GetGCD_NumberIsEqualToOne_ExpectReturnOne()
		{
			var gcd = Algorithms.MathUtils.GetGCD(1, 6);
			Assert.AreEqual(1, gcd);

			gcd = Algorithms.MathUtils.GetGCD(6, 1);
			Assert.AreEqual(1, gcd);
		}

		[TestMethod]
		public void GetGCD_RelativelyPrimeNumbers_ExpectReturnOne()
		{
			var a = 2*2*3; //12
			var b = 5*7; //35

			var gcd = Algorithms.MathUtils.GetGCD(a, b);
			Assert.AreEqual(1, gcd);

			gcd = Algorithms.MathUtils.GetGCD(b, a);
			Assert.AreEqual(1, gcd);
		}

		[TestMethod]
		public void GetGCD_NotRelativelyPrimeNumbers_ExpectReturnGCD()
		{
			var a = 2*3*3*5; //90
			var b = 2*5*7; //70

			var gcd = Algorithms.MathUtils.GetGCD(a, b);
			Assert.AreEqual(10, gcd);

			gcd = Algorithms.MathUtils.GetGCD(b, a);
			Assert.AreEqual(10, gcd);
		}

		[TestMethod]
		public void GetGCD_OneIsDivisorOfAnother_ExpectReturnSmallerNumber()
		{
			var a = 2 * 3 * 3 * 5; //90
			var b = 2 * 3 * 5; //30

			var gcd = Algorithms.MathUtils.GetGCD(a, b);
			Assert.AreEqual(30, gcd);

			gcd = Algorithms.MathUtils.GetGCD(b, a);
			Assert.AreEqual(30, gcd);
		}

		[TestMethod]
		public void GetGCD_NumbersAreEqual_ExpectGCDToBeEqualToNumber()
		{
			var gcd = Algorithms.MathUtils.GetGCD(7, 7);
			Assert.AreEqual(7, gcd);
		}
	}
}