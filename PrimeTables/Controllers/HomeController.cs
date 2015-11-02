using System.Web.Mvc;
using PrimeTables.Code.Interfaces;

namespace PrimeTables.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPrimeGenerator _primeGenerator;

        public HomeController(IPrimeGenerator primeGenerator)
        {
            _primeGenerator = primeGenerator;
        }
        public ViewResult Index()
        {
            return View();
        }

        public JsonResult GetPrimes(int count)
        {
            return Json(_primeGenerator.GenerateNumberOfPrimes(count));
        }
    }
}