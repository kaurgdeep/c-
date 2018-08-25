using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoginRegDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

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
                    var user = _context.users.SingleOrDefault(us => us.Email == MyUser.Email);
                    Account account = new Account();
                    account.Balance = 0;
                    account.UserId = user.UserId;
                    var accountAdd = _context.accounts.Add(account);
                    _context.SaveChanges();


                    HttpContext.Session.SetString("UserSessionEmail", user.Email);
                    // grabs all reviews from database
                    //create account for new user with 0 balance and correct user id 

                    return RedirectToAction ("Success");
                }
            } else {
                System.Console.WriteLine ("There were errors adding user returned to index********************");
                return View ("Index");
            }

        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success () {

            // List<User> AllUsers = _context.users.ToList ();
            // List<Account> AllAccounts = _context.accounts.ToList ();
            // ViewBag.AllUsers = AllUsers;
            // ViewBag.AllAccounts = AllAccounts;
            User user = _context.users.SingleOrDefault(us => us.Email == HttpContext.Session.GetString("UserSessionEmail"));
            Account account = _context.accounts.SingleOrDefault(ac => ac.UserId == user.UserId);
            ViewBag.User = user;    
            ViewBag.Account = account;

            List<Transaction> transactions = _context.transactions.ToList();
            ViewBag.transactions = transactions;
            
            return View ();
        }


        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(string email, string Password){
            
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetString("UserSessionEmail", user.Email);
                    
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

        [HttpPost]
        public IActionResult AddTransaction(Transaction transaction) 
        {
            //I AM ALSO COMMENTING!
            //query db for user in session
            var user = _context.users.SingleOrDefault(us => us.Email == HttpContext.Session.GetString("UserSessionEmail"));
            // in the db's account table... find where the userid is equal to the currently-loggedin users id using the user we got from the line above.
            var account = _context.accounts.SingleOrDefault(ac => ac.UserId == user.UserId);
            transaction.AccountId = account.AccountId;
            account.Balance += transaction.Amount;
            _context.Add(transaction);
            _context.SaveChanges();                                
                                            
            return RedirectToAction("Success");
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

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}