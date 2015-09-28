using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace Algorithms.Tests.MathUtils
{
	[TestClass]
	public class LCMTests
	{
		[TestMethod]
		public void GetLCM_NumbersAreEqualToZero_ExpectReturnZero()
		{
			var lcm = Algorithms.MathUtils.GetLCM(0, 0);

			Assert.AreEqual(0, lcm);
		}

		[TestMethod]
		public void GetLCM_OneNumberIsEqualToZero_ExpectReturnZero()
		{
			var lcm = Algorithms.MathUtils.GetLCM(6, 0);
			Assert.AreEqual(0, lcm);

			lcm = Algorithms.MathUtils.GetLCM(0, 6);
			Assert.AreEqual(0, lcm);
		}

		[TestMethod]
		public void GetLCM_OneNumberIsEqualToOne_ExpectReturnAnother()
		{
			var lcm = Algorithms.MathUtils.GetLCM(6, 1);
			Assert.AreEqual(6, lcm);

			lcm = Algorithms.MathUtils.GetLCM(1, 6);
			Assert.AreEqual(6, lcm);
		}

		[TestMethod]
		public void GetLCM_NumbersAreRelativelyPrime_ExpectReturnProduct()
		{
			var a = 2 * 2 * 3; //12
			var b = 5 * 7; //35

			var lcm = Algorithms.MathUtils.GetLCM(a, b);
			Assert.AreEqual(a * b, lcm);

			lcm = Algorithms.MathUtils.GetLCM(b, a);
			Assert.AreEqual(a * b, lcm);
		}


		[TestMethod]
		public void GetLCM_NumbersAreNotRelativelyPrime_ExpectReturnLCM()
		{
			var a = 2 * 3 * 3 * 5; //90
			var b = 2 * 5 * 7; //70

			var expectedResult = 2*3*3*5*7;

			var lcm = Algorithms.MathUtils.GetLCM(a, b);
			Assert.AreEqual(expectedResult, lcm);

			lcm = Algorithms.MathUtils.GetLCM(b, a);
			Assert.AreEqual(expectedResult, lcm);
		}

		[TestMethod]
		public void GetLCM_OneIsDivisorOfAnother_ExpectReturnAnother()
		{
			var a = 2 * 3 * 3 * 5; //90
			var b = 2 * 3 * 5; //30

			var lcm = Algorithms.MathUtils.GetLCM(a, b);
			Assert.AreEqual(a, lcm);

			lcm = Algorithms.MathUtils.GetLCM(b, a);
			Assert.AreEqual(a, lcm);
		}
	}
}