using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;// for session to handle GetString & GetInt32 (and Set counterparts)
using Microsoft.AspNetCore.Mvc;
using mvc_basics_assign_1_3.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvc_basics_assign_1_3.Controllers
{
    public class CompareNumberController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TestNumber()
        {
            if (HttpContext.Session.GetInt32("numberToGuess") == null)
            {
                HttpContext.Session.SetInt32("numberToGuess", new Random().Next(1, 101));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestNumber(int userGuess)
        {
            if (HttpContext.Session.GetInt32("numberToGuess") == null)
            {
                HttpContext.Session.SetInt32("numberToGuess", new Random().Next(1, 101));
            }


            int numberToGuess = (int)HttpContext.Session.GetInt32("numberToGuess");

            ViewBag.number = GuessingService.CheckNumber(userGuess, numberToGuess);

            if (numberToGuess == userGuess)
            {
                HttpContext.Session.SetInt32("numberToGuess", new Random().Next(1, 101));
            }

            return View();

        }
    }
}
