using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Models;

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
        public IActionResult Index(float temp,string tempScale)
        {
            ViewBag.fever = FeverCheck.GetFeverResponse(temp, tempScale)+tempScale;
        return View();
        }
               
    }
}





