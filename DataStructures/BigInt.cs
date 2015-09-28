using System;
using System.Text;

namespace DataStructures
{
	/// <summary>
	///     Big integer representation.
	///     Only for positive numbers and zero for now.
	/// </summary>
	public class BigInt
	{
		private const int MAX_DIGITS = 10000;

		public BigInt()
		{
			Length = 1;
			Digits = new int[MAX_DIGITS];
		}

		public BigInt(long a) : this()
		{
			while (a > 0)
			{
				Digits[Length - 1] = (int) a%10;
				a = a/10;
				Length++;
			}

			if (Length > 1)
			{
				Length--;
			}
		}

		private int[] Digits { get; set; }
		public int Length { get; private set; }

		public static BigInt operator +(BigInt a, BigInt b)
		{
			return Add(a, b);
		}

		public static BigInt Add(BigInt a, BigInt b)
		{
			var length = Math.Max(a.Length, b.Length);
			var result = new BigInt {Length = length};

			for (var i = 0; i < length; i++)
			{
				var temp = result.Digits[i] + a.Digits[i] + b.Digits[i];
				result.Digits[i] = temp%10;
				result.Digits[i + 1] = (temp)/10;
			}

			while (result.Digits[result.Length] > 0)
			{
				result.Length++;
			}
			return result;
		}

		public static BigInt operator *(BigInt a, BigInt b)
		{
			return Multiply(a, b);
		}

		public static BigInt Multiply(BigInt a, BigInt b)
		{
			var result = new BigInt();

			if (a.IsZero() || b.IsZero())
			{
				return result;
			}

			for (var i = 0; i < a.Length; i++)
			{
				var p = 0;
				for (var j = 0; j < b.Length; j++)
				{
					var temp = a.Digits[i]*b.Digits[j] + p + result.Digits[i + j];
					result.Digits[i + j] = temp%10;
					p = temp/10;
				}
				result.Digits[i + b.Length] = p;
			}

			result.Length = a.Length + b.Length - 1;
			while (result.Digits[result.Length] > 0)
			{
				result.Length++;
			}
			return result;
		}

		private bool IsZero()
		{
			return Length == 1 && Digits[0] == 0;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			for (var i = Length - 1; i >= 0; i--)
			{
				sb.Append(Digits[i]);
			}
			return sb.ToString();
		}
	}
}