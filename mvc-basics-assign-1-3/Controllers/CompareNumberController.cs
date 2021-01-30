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
        [HttpGet]
        public IActionResult TestLetter()
        {
           
            if (HttpContext.Session.GetInt32("LetterToGuess") == null)
            {
                HttpContext.Session.SetInt32("LetterToGuess", new Random().Next(1, 28));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestNumber(string userGuess)
        {
             var alphabet = ['a','b','c','d','e','f','g','h','i','j','k','l',
                           'm','n','o','p','q','r','s','t','u','v','w','x','y','z'];
            if (HttpContext.Session.GetInt32("LetterToGuess") == null)
            {
                HttpContext.Session.SetInt32("LetterToGuess", new Random().Next(1, 28));
            }

             var wins = 0;
             var losses = 0;
             var guesses = 10;

             var computerChoice = alphabet[Math.floor(Math.random() * alphabet.length)];

             console.log(computerChoice)



            // When the user presses a key, it will run the following function...
            document.onkeypress = function(event) {
            var userGuess = event.key;

            if(userGuess === computerChoice){
            wins++;
            }else{
            guesses--;
            }

            if(guesses === 0){
            losses++
            }

            document.getElementById('wins').innerHTML = "Wins: " + wins;
            document.getElementById('losses').innerHTML = "losses: " + losses;
            document.getElementById('guesses').innerHTML = "Guesses left: " + guesses;

            return View();

        }


    }
}
