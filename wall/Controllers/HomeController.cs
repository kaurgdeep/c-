using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace wall.Controllers
{
    public class HomeController : Controller
    {
        private WallContext _context;
 
        public HomeController(WallContext context)
        {
            _context = context;
        }

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

        [HttpPost("reg")]
        public IActionResult reg(User user, string ConfirmPass)
        {
            if(ModelState.IsValid && ConfirmPass == user.Password)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.users.Add(user);
                _context.SaveChanges();
            return View("Message", User);
            }
            else
            {
                return View("Index");
            }
        }
        
        [HttpPost("login")]
        public IActionResult login(string Email, string PasswordToCheck)
        {
            var Hasher = new PasswordHasher<User>();
            // Attempt to retrieve a user from your database based on the Email submitted
            var check = _context.users.Where(x => x.Email == Email).FirstOrDefault();
            if(check != null && PasswordToCheck != null)
            {// Pass the user object, the hashed password, and the PasswordToCheck
                if(0 != Hasher.VerifyHashedPassword(check, check.Password, PasswordToCheck))
                {
                    return View("Message", check); //Handle success
                }
                
            }
            return RedirectToAction("Index");
            //Handle failure
        }
        [HttpPost("submit")]
        public IActionResult message()
        {
            _context.users.Add(Message);
            _context.SaveChanges();

            return RedirectToAction("msg");
        }

        public IActionResult msg()
        {
             List<Message> Allmessages = _context.users.Include(x => x.;
        }


    }
}
