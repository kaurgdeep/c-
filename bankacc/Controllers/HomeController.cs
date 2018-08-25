using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankacc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace bankacc.Controllers
{
    public class HomeController : Controller
    {
         private UserContext _context;
 
        public HomeController(UserContext context)
        {
            _context = context;
        }
 
        public IActionResult Index()
        {
            List<Person> AllUsers = _context.users.ToList();
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

        [HttpPost("reg")]
        public IActionResult reg(Person person, string ConfirmPass)
        {
            if(ModelState.IsValid && ConfirmPass == person.Password)
            {
                PasswordHasher<Person> Hasher = new PasswordHasher<Person>();
                person.Password = Hasher.HashPassword(person, person.Password);
                _context.Add(person);
                _context.SaveChanges();

                
            return View("Account", person);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult login(string Email, string PasswordToCheck)
        {
            // Attempt to retrieve a user from your database based on the Email submitted
            var check = _context.users.Where(x => x.Email == Email).FirstOrDefault();
            if(check != null && PasswordToCheck != null)
            {
                var Hasher = new PasswordHasher<Person>();
                // Pass the user object, the hashed password, and the PasswordToCheck
                if(0 != Hasher.VerifyHashedPassword(check, check.Password, PasswordToCheck))
                {
                   return View("About", check); //Handle success
                }
            }
            return RedirectToAction("Index");
            //Handle failure
        }
    }
}
