using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace DataStructures.Tests
{
	[TestClass]
	public class BigIntTests
	{
		[TestMethod]
		public void Create_Default_ExpectEqualToZero()
		{
			var bigInt = new BigInt();
			Assert.AreEqual("0", bigInt.ToString());
		}

		[TestMethod]
		public void Create_FromZero_ExpectEqualToZero()
		{
			var bigInt = new BigInt(0);
			Assert.AreEqual("0", bigInt.ToString());
		}

		[TestMethod]
		public void Create_FromPositiveNumber_ExpectEqualToNumber()
		{
			var number = 12345678;
			var bigInt = new BigInt(number);

			Assert.AreEqual(number.ToString(), bigInt.ToString());
		}

		[TestMethod]
		public void Add_TwoZeroNumbers_ExpectEqualToZero()
		{
			var zero1 = new BigInt();
			var zero2 = new BigInt();

			var sum = BigInt.Add(zero1, zero2);

			Assert.AreEqual("0", sum.ToString());
		}

		[TestMethod]
		public void Add_ZeroAndPositive_ExpectEqualToPositive()
		{
			var a = 829499221;

			var zero = new BigInt();
			var positive = new BigInt(a);

			var sum = BigInt.Add(zero, positive);
			Assert.AreEqual(a.ToString(), sum.ToString());

			sum = BigInt.Add(positive, zero);
			Assert.AreEqual(a.ToString(), sum.ToString());
		}

		[TestMethod]
		public void Add_TwoPositiveResultSameLength_ExpectReturnSum()
		{
			var a = 12345;
			var b = 321;

			var expectedResult = 12666;

			var positive1 = new BigInt(a);
			var positive2 = new BigInt(b);

			var sum = BigInt.Add(positive1, positive2);
			Assert.AreEqual(expectedResult.ToString(), sum.ToString());

			sum = BigInt.Add(positive2, positive1);
			Assert.AreEqual(expectedResult.ToString(), sum.ToString());
		}

		[TestMethod]
		public void Add_TwoPositiveResultIsLonger_ExpectReturnSum()
		{
			var a = 999;
			var b = 111;

			var expectedResult = 1110;

			var positive1 = new BigInt(a);
			var positive2 = new BigInt(b);

			var sum = BigInt.Add(positive1, positive2);
			Assert.AreEqual(expectedResult.ToString(), sum.ToString());

			sum = BigInt.Add(positive2, positive1);
			Assert.AreEqual(expectedResult.ToString(), sum.ToString());

			sum = positive1 + positive2;
			Assert.AreEqual(expectedResult.ToString(), sum.ToString());
		}

		[TestMethod]
		public void Multiply_TwoZeroNumbers_ExpectEqualToZero()
		{
			var zero1 = new BigInt();
			var zero2 = new BigInt();

			var product = BigInt.Multiply(zero1, zero2);

			Assert.AreEqual("0", product.ToString());
		}

		[TestMethod]
		public void Multiply_ZeroAndPositive_ExpectEqualToZero()
		{
			var zero = new BigInt();
			var positive = new BigInt(123);

			var product = BigInt.Multiply(zero, positive);
			Assert.AreEqual("0", product.ToString());

			product = BigInt.Multiply(positive, zero);
			Assert.AreEqual("0", product.ToString());
		}

		[TestMethod]
		public void Multiply_TwoPositiveResultSameLength_ExpectReturnProduct()
		{
			var a = 11111;
			var b = 9;

			var expectedResult = 99999;

			var positive1 = new BigInt(a);
			var positive2 = new BigInt(b);

			var product = BigInt.Multiply(positive1, positive2);
			Assert.AreEqual(expectedResult.ToString(), product.ToString());

			product = BigInt.Multiply(positive2, positive1);
			Assert.AreEqual(expectedResult.ToString(), product.ToString());
		}

		[TestMethod]
		public void Multiply_TwoPositiveResultIsLonger_ExpectReturnProduct()
		{
			var a = 987;
			var b = 123;

			var expectedResult = 121401;

			var positive1 = new BigInt(a);
			var positive2 = new BigInt(b);

			var product = BigInt.Multiply(positive1, positive2);
			Assert.AreEqual(expectedResult.ToString(), product.ToString());

			product = BigInt.Multiply(positive2, positive1);
			Assert.AreEqual(expectedResult.ToString(), product.ToString());

			product = positive1 * positive2;
			Assert.AreEqual(expectedResult.ToString(), product.ToString());
		}

		[Ignore]
		[TestMethod]
		public void UltimateTest()
		{
			for (var i = 0; i < 1000; i++)
			{
				var a = new BigInt(i);
				for (var j = i + 1; j < 500; j++)
				{
					var b = new BigInt(j);

					var sum = a + b;
					var product = a*b;

					Assert.AreEqual(sum.ToString(), (i + j).ToString());
					Assert.AreEqual(product.ToString(), (i * j).ToString());
				}
			}
		}
	}
}