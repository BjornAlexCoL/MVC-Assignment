using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers
{
    public class NumberGuessing : Controller
    {       
        [HttpGet]
        public IActionResult Index()
        {
            NumberGuessingService.GetNumber();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int guess)
        {
            ViewBag.response = NumberGuessingService.EvaluateGuess(guess);
            return View();
        }

    }
}
