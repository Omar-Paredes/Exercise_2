using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_basics_assign_1_3.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvc_basics_assign_1_3.Controllers
{
    public class TemperatureController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Check()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Check(double bodyTemperature)
        {
            ViewBag.diagnose = CheckFever.TempCheck(bodyTemperature);
            return View();
        }
    }
}
