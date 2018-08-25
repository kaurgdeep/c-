using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using random_passcode.Models;

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        public static Random rnd = new Random();

        public static int Counter = 0;
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("generate")]
        public IActionResult generate()
        {
           var Chars = "ABCDEFGHIJKLMNOPQRSTUVWXVZ0123456789";
           var StringChars = "";
           Counter++;

            ViewBag.count = Counter;
            

            for(var i = 0; i < 14; i++)
            {
                StringChars += Chars[rnd.Next(0,Chars.Count())];
            }

            return View("Index", StringChars);
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
