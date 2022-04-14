using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers
{
    public class NumberGuessing : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Random rnd = new Random();

            HttpContext.Session.SetInt32("Number", rnd.Next(1, 101));
            HttpContext.Session.SetInt32("Guesses", 0);

            string HighScores = HttpContext.Session.GetString("HighScores");
            if (HighScores != null)
            {
                ViewBag.Memos = HighScores;
            }

            return View();
        }
        [HttpPost]
        public IActionResult Index(int guess)
        {
            int guesses= (int)HttpContext.Session.GetInt32("Guesses");
            int number = (int)HttpContext.Session.GetInt32("Number");

            HttpContext.Session.SetInt32("Guesses", ++guesses);

            if (guess == number)
            {
                ViewBag.response = $"Congratulation you guessed right in {guesses} guesses!";
                //RedirectToAction("Index");
            }
            else
            {
                ViewBag.response = $"You have guessed {guesses} so fare!";
                ViewBag.response += $" The number i am thingking of is {((guess < number) ? "higher" : "lesser")} then you guessed";
            }

            return View();
        }

    }
}
