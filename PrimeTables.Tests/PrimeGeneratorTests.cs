using System.Collections.Generic;
using NUnit.Framework;
using PrimeTables.Code;
using PrimeTables.Code.Interfaces;

namespace PrimeTables.Tests
{
    [TestFixture]
    public class PrimeGeneratorTests
    {
        private readonly IPrimeGenerator _primeGenerator = new PrimeGenerator();

        [Test]
        public void GeneratePrimesToCount_0_EmptyEnumerableReturned()
        {
            var result = _primeGenerator.GenerateNumberOfPrimes(0);

            Assert.AreEqual(new List<int>(), result);
        }

        [Test]
        public void GeneratePrimesToCount_2_FirstTwoPrimesReturned()
        {
            var result = _primeGenerator.GenerateNumberOfPrimes(2);

            Assert.AreEqual(new List<int> {2,3}, result);
        }

        [Test]
        public void GeneratePrimesToCount_10_FirstTenPrimesReturned()
        {
            var result = _primeGenerator.GenerateNumberOfPrimes(10);

            Assert.AreEqual(new List<int> {2,3,5,7,11,13,17,19,23,29}, result);
        }

        [Test]
        public void GeneratePrimesToCount_100_100PrimesReturned()
        {
            var result = _primeGenerator.GenerateNumberOfPrimes(100);

            Assert.AreEqual(100, result.Count);
        }
    }
}