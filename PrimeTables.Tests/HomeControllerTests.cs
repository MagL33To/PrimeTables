using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PrimeTables.Code.Interfaces;
using PrimeTables.Controllers;

namespace PrimeTables.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _fakeHomeController;
        private Mock<IPrimeGenerator> _fakePrimeGenerator;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _fakePrimeGenerator = new Mock<IPrimeGenerator>();
            _fakeHomeController = new HomeController(_fakePrimeGenerator.Object);
        }

        [Test]
        public void GetPrimes_ValidIntegerSupplied_ReturnJsonResult()
        {
            const int count = 5;
            var list = Enumerable.Range(0, count).ToList();

            _fakePrimeGenerator.Setup(x => x.GenerateNumberOfPrimes(It.IsAny<int>()))
                .Returns(list);

            var result = _fakeHomeController.GetPrimes(count);

            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void GetPrimes_ValidIntegerSupplied_NonNullDataReturned()
        {
            const int count = 5;
            var list = Enumerable.Range(0, count).ToList();

            _fakePrimeGenerator.Setup(x => x.GenerateNumberOfPrimes(It.IsAny<int>()))
                .Returns(list);

            var result = _fakeHomeController.GetPrimes(count);

            Assert.That(result.Data, Is.Not.Null);
        }
    }
}