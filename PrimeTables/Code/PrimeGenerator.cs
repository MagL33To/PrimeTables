using System;
using System.Collections.Generic;
using System.Linq;
using PrimeTables.Code.Interfaces;

namespace PrimeTables.Code
{
    public class PrimeGenerator : IPrimeGenerator
    {
        public IList<int> GenerateNumberOfPrimes(int count)
        {
            var estimate = 35;
            var numPrimes = Convert.ToInt64(estimate/Math.Log(estimate));
            while (numPrimes < count)
            {
                estimate = estimate*estimate;
                numPrimes = Convert.ToInt64(estimate / Math.Log(estimate));
            }

            return Sieve(estimate).Take(count).ToList();
        }

        private static IEnumerable<int> Sieve(long n)
        {
            var bools = new bool[n];

            for (var i = 2; i < n; i++)
            {
                bools[i] = true;
            }

            for (var j = 2; j < n; j++)
            {
                if (bools[j])
                {
                    for (var k = 2; (k * j) < n; k++)
                    {
                        bools[k * j] = false;
                    }

                    yield return j;
                }
            }
        }
    }
}