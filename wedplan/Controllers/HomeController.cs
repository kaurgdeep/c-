using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wedplan.Models;
using Microsoft.EntityFrameworkCore;


namespace wedplan.Controllers
{
    public class HomeController : Controller
    {
        private WedContext _context;

        public HomeController (WedContext context) {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
             ViewBag.LoggedUser = _context.users.SingleOrDefault(user => (user.UserId == HttpContext.Session.GetInt32("userID")));
            // List<ActivityPlan> allofthem = _context.ActivityPlans.Include(a => a.User).Where(a => a.StartDate > DateTime.Now).OrderBy(a => a.StartDate).ToList();
            ViewBag.AllWeddings = _context.weddings.Include(a => a.user).Include(a => a.Guests).Where(a => a.Date > DateTime.Now).OrderBy(a => a.Date).ToList();
            // var stuff = _context.ActivityPlans.Include(a => a.User).Include(a => a.AttendingUsers).ThenInclude(uap => uap.User).ToList();

            return View();
        }

        [Route("Home/delete/{id}")]
        public IActionResult delete(int id)
        {
            Wedding Removewedding = _context.weddings.SingleOrDefault(w => w.WeddingId == id);
            _context.weddings.Remove(Removewedding);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        [Route("Home/unrsvp/{id}")]
        public IActionResult unrsvp(int id)
        {
           
            User users = _context.users.SingleOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("userID"));
            Guest deleteMe = _context.guests.SingleOrDefault(a => a.WeddingId == id && a.UserId == users.UserId);
            _context.Remove(deleteMe);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("Home/rsvp/{id}")]
        public IActionResult rsvp(int id)
        {
            Guest addMe = new Guest()
            {
                UserId = (int)HttpContext.Session.GetInt32("userID"),
                WeddingId = id
            };

            _context.Add(addMe);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public IActionResult Details()
        {
            
            return View();
        }

       [Route("Home/namelink/{id}")]

        public IActionResult namelink(int id)
        {
            // var ids = id;
            Wedding Wedding = _context.weddings.SingleOrDefault(wd => wd.WeddingId == id);
            List<Wedding> Guests = _context.weddings.Include(ig => ig.Guests).ToList();
            ViewBag.Wedding = Wedding;
            ViewBag.Guests = Guests;
            return View("Details");
        }

        [Route("Home/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [Route("Home/NewWedding")]
        public IActionResult NewWedding()
        {
            if (HttpContext.Session.GetInt32("userID") == null) {
            return RedirectToAction("Index");
           
            }
            // User users = _context.users.SingleOrDefault(us => us.Email == HttpContext.Session.GetString("userEmail"));
            // ViewBag.User = users;
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }
        [HttpPost]
        // [Route("process")]
        public IActionResult process(Wedding createwedding){
            if (ModelState.IsValid){
                var UserEmail = HttpContext.Session.GetString("userEmail");
                User existingUser = _context.users.SingleOrDefault(u => u.Email==UserEmail);

                createwedding.UserId = existingUser.UserId;
                _context.Add(createwedding);
                _context.SaveChanges(); 
                return RedirectToAction("Details");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid Wedding";
                    return RedirectToAction("NewWedding");
                }
        }
        [Route("Home/dashboardbutton")]
        public IActionResult dashboardbutton()
        {
            return RedirectToAction("Dashboard");
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
                    return RedirectToAction ("Dashboard");
                }
            } else {
                System.Console.WriteLine ("There were errors adding user returned to index********************");
                return View ("Index");
            }

        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult Login(string email, string Password){
            
            var users = _context.users.SingleOrDefault(u => u.Email == email);
            if(users != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(users, users.Password, Password)){
                    HttpContext.Session.SetString("userEmail", email);
                    HttpContext.Session.SetInt32("userID", users.UserId);
                    return RedirectToAction("Dashboard");
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
        
    }
}
