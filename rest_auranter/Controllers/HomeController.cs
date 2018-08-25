using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_auranter.Models;
using Microsoft.EntityFrameworkCore;

namespace rest_auranter.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;
 
    public HomeController(YourContext context)
    {
        _context = context;
    }
 
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        List<Person> AllUsers = _context.Users.ToList();
        // Other code
        System.Console.WriteLine(AllUsers);
        System.Console.WriteLine(AllUsers);
        System.Console.WriteLine(AllUsers);
        System.Console.WriteLine(AllUsers);
        System.Console.WriteLine(AllUsers);
        System.Console.WriteLine(AllUsers);

        foreach(var user in AllUsers) {
            System.Console.WriteLine(user.name);
        }

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
    }
}
