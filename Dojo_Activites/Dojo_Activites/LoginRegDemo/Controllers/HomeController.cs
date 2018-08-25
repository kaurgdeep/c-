using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoginRegDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LoginRegDemo.Controllers {
    public class HomeController : Controller {

        private UserContext _context;
        private object userFactory;

        public HomeController (UserContext context) {
            _context = context;
        }

        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        [Route ("RegisterUser")]
        public IActionResult RegisterUser (User MyUser, string ConfirmPassword) {
            
            System.Console.WriteLine ("WE HIT REGISTERED USER FUNCTION IN CONTROLLER");
            if(MyUser.Password != ConfirmPassword) {
                System.Console.WriteLine("DAMN HOMIE your passwords dont match **************************");
                ViewBag.PasswordError = $"{MyUser.FirstName} I'm so terribly sorry but I'm a robot and I don't understand why you would type passwords that don't match. THANKS FOR PLAYING. TRY AGAIN!";
                return View ("Index");
            }

            if (ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                MyUser.Password = Hasher.HashPassword(MyUser, MyUser.Password);
                User ExistingUser = _context.users.SingleOrDefault (u => u.Email == MyUser.Email);
                if (ExistingUser != null) {
                    System.Console.WriteLine (" *************EMAIL ALREADY IN USE**********************");
                    ViewBag.AlreadyInUseEmail = true;
                    // ViewBag.AlreadyInUseEmail = $"{MyUser.Email} is already in the Data base, YOU FUCK!";
                    return View ("Index");
                    // Yo dude Have you ever watched Mike Tyson Mysteries? Its really good show.
                }
                else{
                    _context.Add (MyUser);
                    _context.SaveChanges ();

                    HttpContext.Session.SetString("userEmail", MyUser.Email);
                    HttpContext.Session.SetInt32("userID", MyUser.UserId);
                    // var user = HttpContext.Session.GetInt32("userId");

                    // grabs all reviews from database
                    return RedirectToAction ("Success");
                }
            } else {
                System.Console.WriteLine ("There were errors adding user returned to index********************");
                return View ("Index");
            }

        }

        [Route("Home")]
        public IActionResult Success () {
            var userEmail = HttpContext.Session.GetString("userEmail");
            User users = _context.users.SingleOrDefault(u => u.Email == userEmail);
            ViewBag.User = users;
            return View ("Home");
        }

        [Route("New")]
        public IActionResult New() {

            return View();
        }

        [HttpPost]
        public IActionResult Process(Event events) {
            var UserEmail = HttpContext.Session.GetString("userEmail");
            User Users = _context.users.SingleOrDefault(u => u.Email == UserEmail);

            if(ModelState.IsValid) {
            events.UserId = Users.UserId;
            _context.Add(events);
            _context.SaveChanges();
            System.Console.WriteLine(Users.UserId);

            HttpContext.Session.SetInt32("eventID", events.EventId);

            return RedirectToAction("SingleEvent");

            }
            else {
                return View("New");
            }

        }

        public IActionResult SingleEvent () {
            int? eventsID = HttpContext.Session.GetInt32("eventID");
            Event events = _context.events.SingleOrDefault(u => u.EventId == eventsID);
            ViewBag.Events = events;
            return View();
        }



        // [HttpPost]
        // [Route ("LoginUser")]
        // public IActionResult LoginUser (string Email, string Password) {
        //     //is user in database???? Use where or Singleordefault or firstordefault
        //     //check queried user's password against our passed in password

        //     //go to success(maybe add stuff to session first?)
        //     //otherwise, get some error messages to our user
        //     return RedirectToAction ("Index");
        // }
        [HttpPost]
        [Route("LoginUser")]
        public IActionResult Login(string email, string Password){
            
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetString("userEmail", email);
                    HttpContext.Session.SetInt32("userID", user.UserId);
                    return RedirectToAction("Success");
                }
                else{
                    System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");
                    System.Console.WriteLine("Else for login if password doesnt match");
                    System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");

                    ViewBag.loginError = "Wrong password!";
                    return View("Index");
                }
            }
            else{
                System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");
                System.Console.WriteLine("Else for login email doesnt exist");
                System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");

                ViewBag.loginError = "Email not registered";
                return View("Index");
            }
            
        }


        // public IActionResult About()
        // {
        //     ViewData["Message"] = "Your application description page.";

        //     return View();
        // }

        // public IActionResult Contact()
        // {
        //     ViewData["Message"] = "Your contact page.";

        //     return View();
        // }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}