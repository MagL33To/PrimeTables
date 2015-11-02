using System.Collections.Generic;
using System.Linq;
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
            return Json(GenerateMultiplicationTable(_primeGenerator.GenerateNumberOfPrimes(count)), JsonRequestBehavior.AllowGet);
        }

        private static List<List<int>> GenerateMultiplicationTable(IList<int> primes)
        {
            var table = new List<List<int>> {new List<int> {0}.Concat(primes).ToList()};
            foreach (var prime in primes)
            {
                var column = new List<int> {prime};
                column.AddRange(primes.Select(x => x*prime));
                table.Add(column);
            }
            return table;
        }
    }
}