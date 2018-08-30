using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RazorViewEngine.Controllers
{
    public class IndexController : Controller
    {
        [HttpGet]
        [Route("")]

        public IActionResult Index()
        {
            // List<string> Icecreams = new List<string>();

            // Icecreams.Add("choco");
            // Icecreams.Add("strawberry");
            // Icecreams.Add("coconut");
            // Icecreams.Add("pineapple");

            // string CurUser = "Gagandeep";
            // ViewBag.User = CurUser;
            // ViewBag.Icecreams = Icecreams;

            return View("Index");


        }
    }

}