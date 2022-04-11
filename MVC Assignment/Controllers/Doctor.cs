using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment.Controllers
{
    public class Doctor : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(float temp)
        {
            ViewBag.fever = "You look healty. Time to work!";
            if (temp >= 37)
            {
                ViewBag.fever = "I, as a computer, would say you got some fever";
            }
            if (temp < 35)
            {
                ViewBag.fever = "I, as a computer, would say you are more or less dead";
            }
        return View();
        }
               
    }
}





