using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}