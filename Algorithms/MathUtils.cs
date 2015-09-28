namespace Algorithms
{
	public static class MathUtils
	{
		/// <summary>
		/// Least common multiple
		/// </summary>
		public static int GetLCM(int a, int b)
		{
			if (a == 0 && b == 0)
			{
				return a + b;
			}

			//NOTE overflow is possible
			return System.Math.Abs(a * b) / GetGCD(a, b);
		}

		/// <summary>
		/// Greatest common divisor. Euclid's algorithm
		/// https://en.wikipedia.org/wiki/Greatest_common_divisor
		/// http://algolist.manual.ru/maths/teornum/nod.php#2
		/// </summary>
		public static int GetGCD(int a, int b)
		{
			while (a != 0 && b != 0)
			{
				if (a >= b) a = a % b;
				else b = b % a;
			}
			return a + b;
		}
	}
}