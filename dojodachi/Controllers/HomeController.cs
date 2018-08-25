using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using dojodachi.Models;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // if (HttpContext.Session.GetInt32("energy") == 100 && HttpContext.Session.GetInt32("fullness") == 100 && HttpContext.Session.GetInt32("happiness") == 100){

            // }
            if (HttpContext.Session.GetInt32("fullness") == null) {
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetInt32("happiness", 20);
                HttpContext.Session.SetInt32("meals", 3);
                HttpContext.Session.SetInt32("energy", 50);
            }

            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");
            ViewBag.fullness = fullness;
            ViewBag.happiness = happiness;
            ViewBag.energy = energy;
            ViewBag.meals = meals;
            return View();
        }
        [HttpPost("feed")]
        public IActionResult feed()
        {
            Random rand = new Random();
            if((int)HttpContext.Session.GetInt32("meals") > 0)
            {
                int temp=rand.Next(5,10);
                int full = (int)HttpContext.Session.GetInt32("fullness");
                HttpContext.Session.SetInt32("fullness", full+=temp);
                int? fullness = HttpContext.Session.GetInt32("fullness");

                int test = (int)HttpContext.Session.GetInt32("meals");
                HttpContext.Session.SetInt32("meals", test-=1);
                int? meals = HttpContext.Session.GetInt32("meals");
                System.Console.WriteLine(meals);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("play")]
        public IActionResult play()
        {
            Random rand = new Random();
                int temp=rand.Next(5,10);
                int play = (int)HttpContext.Session.GetInt32("happiness");
                HttpContext.Session.SetInt32("happiness", play+=temp);
                int? fullness = HttpContext.Session.GetInt32("happiness");

                int test = (int)HttpContext.Session.GetInt32("energy");
                HttpContext.Session.SetInt32("energy", test-=5);
                int? energy = HttpContext.Session.GetInt32("energy");
                

            return RedirectToAction("Index");
        }
        [HttpPost("work")]
        public IActionResult work()
        {
            Random rand = new Random();
                int temp=rand.Next(1,3);
                int work = (int)HttpContext.Session.GetInt32("meals");
                HttpContext.Session.SetInt32("meals", work+=temp);
                int? fullness = HttpContext.Session.GetInt32("meals");

                int test = (int)HttpContext.Session.GetInt32("energy");
                HttpContext.Session.SetInt32("energy", test-=5);
                int? energy = HttpContext.Session.GetInt32("energy");
                

            return RedirectToAction("Index");
        }
        [HttpPost("sleep")]
        public IActionResult sleep()
        {
                int sleep = (int)HttpContext.Session.GetInt32("energy");
                HttpContext.Session.SetInt32("energy", sleep+=15);
                int? energy = HttpContext.Session.GetInt32("energy");

                int full = (int)HttpContext.Session.GetInt32("fullness");
                HttpContext.Session.SetInt32("fullness", full-=5);
                int? fullness = HttpContext.Session.GetInt32("fullness");

                int happy = (int)HttpContext.Session.GetInt32("happiness");
                HttpContext.Session.SetInt32("happiness", happy-=5);
                int? happiness = HttpContext.Session.GetInt32("happiness");
                

            return RedirectToAction("Index");
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
    }
}
