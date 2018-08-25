using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RESTContext _context;
 
        public HomeController(RESTContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            
   
   

            // foreach(var user in Allreviews) {
            //     System.Console.WriteLine(user.reviewername);
            //}

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
        
        [HttpPost]
        [Route("submit")]
        public IActionResult submit(review Review)
        {  
            _context.users.Add(Review);
            _context.SaveChanges();

            
            
            return RedirectToAction("reviews");
        }

        public IActionResult reviews()
        { 
            List<review> Allreviews = _context.users.OrderByDescending(u => u.date).ToList();
            ViewBag.users = Allreviews;
            // System.Console.WriteLine(Allreviews);
            // foreach(var review in Allreviews)
            // {
            //     System.Console.WriteLine(review.reviewername);
            // }
            
            
            return View("Contact");
        }
        
    }
}
