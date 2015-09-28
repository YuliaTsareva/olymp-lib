using System.Collections.Generic;

namespace Algorithms
{
	public static class Primes
	{
		/// <summary>
		/// Return prime numbers less or equal to k
		/// Sieve of Eratosthenes
		/// </summary>
		public static int[] GetPrimes(int k)
		{
			var notPrime = new bool[k + 1];

			for (var i = 2; i * i <= k; i++)
			{
				if (!notPrime[i])
				{
					var j = i;
					while (i * j <= k)
					{
						notPrime[i * j] = true;
						j++;
					}
				}
			}

			var primes = new List<int>();
			for (int i = 2; i <= k; i++)
			{
				if (!notPrime[i])
				{
					primes.Add(i);
				}
			}

			return primes.ToArray();
		}

		public static bool IsPrime(int k)
		{
			if (k < 2)
			{
				return false;
			}

			for (int i = 2; i * i <= k; i++)
			{
				if (k%i == 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}