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

            ViewBag.highScores = Request.Cookies["HighScores"];

            ViewBag.AddToHighScore = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int guess)
        {
            int guesses = (int)HttpContext.Session.GetInt32("Guesses");
            int number = (int)HttpContext.Session.GetInt32("Number");

            HttpContext.Session.SetInt32("Guesses", ++guesses);

            if (guess == number)
            {
                ViewBag.response = $"Congratulation you guessed right in {guesses} guesses!";
                ViewBag.addToHighScore = true;
                //RedirectToAction("Index");
            }
            else
            {
                ViewBag.response = $"You have guessed {guesses} so fare!";
                ViewBag.response += $" The number i am thingking of is {((guess < number) ? "higher" : "lesser")} then you guessed";
                ViewBag.addToHighScore = false;
            }
            ViewBag.highScores =  Request.Cookies["HighScores"];

            return View();
        }
        [HttpPost]
        public IActionResult AddToHighScore(string name)
        {
            string highScoreLine=HttpContext.Session.GetInt32("Guesses").ToString();
            if (!string.IsNullOrWhiteSpace(name))
            {
                string highScores = Request.Cookies["HighScores"];
                highScoreLine += "\t" + DateTime.Now.ToString()+"\t"+name;
                if (highScores == null)
                {
                    Response.Cookies.Append("HighScores", highScoreLine);
                }
                else
                {
                    highScores += '\n' + highScoreLine;
                    Response.Cookies.Append("HighScores", highScores);
                }
            }

            return RedirectToAction(nameof(Index));
          
        }
    }
}
