using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newlogin.Models;

namespace newlogin.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;

        public HomeController (YourContext context) {
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
                    // HttpContext.Session.SetString("UserSessionEmail", MyUser.Email);
                    HttpContext.Session.SetString("userEmail", MyUser.Email);
                    HttpContext.Session.SetInt32("userID", MyUser.UserId);

                    return RedirectToAction("brightideas");
                }
            } else {
                System.Console.WriteLine ("There were errors adding user returned to index********************");
                return View ("Index");
            }
        }


         [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(string email, string Password){
            
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    // HttpContext.Session.SetString("UserSessionEmail", user.Email);
                    HttpContext.Session.SetString("userEmail", email);
                    HttpContext.Session.SetInt32("userID", user.UserId);
                    return RedirectToAction("brightideas");
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



        [Route("brightideas")]
        public IActionResult brightideas()
        {
            // var UserEmail = HttpContext.Session.GetString("userEmail");
            if( HttpContext.Session.GetInt32("userID") == null){ //after logout will goto index page
                return RedirectToAction("Index");
            }
            User existingUser = _context.users.SingleOrDefault(u => u.Email == HttpContext.Session.GetString("userEmail"));
            ViewBag.ExistingUser = existingUser;
            ViewBag.ExistingUserId = existingUser.UserId;

            ViewBag.Ideas = _context.ideas.Include(u => u.User).Include(l => l.peopleslike).ThenInclude(u => u.User).OrderByDescending(item => item.peopleslike.Count).ToList();
            ViewBag.LikeError = TempData["LikeError"];
            
            return View("brightideas");
        }

        [HttpPost]
        [Route("postidea")]

        public IActionResult postidea(Idea Anidea)
        {
            var UserEmail = HttpContext.Session.GetString("userEmail");
            User existingUser = _context.users.SingleOrDefault(u => u.Email==UserEmail);

            Anidea.UserId = existingUser.UserId;
            _context.Add(Anidea);
            _context.SaveChanges();
           
                    
            return RedirectToAction("brightideas");
        
        }

        [Route("Like/{id}")]
        public IActionResult Like (int id) {
            
            var UserEmail = HttpContext.Session.GetString("userEmail");
            User ExistingUser = _context.users.SingleOrDefault (u => u.Email == UserEmail);

            var UserID = HttpContext.Session.GetInt32("userID");// this is for 1 person can like a post only ones
            Like ExistingLike = _context.likes.SingleOrDefault(u => u.IdeaId == id && u.UserId == UserID);// this is for 1 person can like a post only ones


            if( ExistingLike == null)// this if is for person already like the post.
            {
            Like like = new Like();
            like.IdeaId = id;
            like.UserId = ExistingUser.UserId;

            _context.Add(like);
            _context.SaveChanges();

            return RedirectToAction("brightideas");
            }
            else
            {
                TempData["LikeError"] = "You already have Like This Post";
                return RedirectToAction("brightideas");
            }
        }

        [Route("delete/{id}")]
        public IActionResult delete (int id){

            Idea CurrentPost = _context.ideas.SingleOrDefault(p => p.IdeaId == id);//this if check not gonna allows other to delete
            if(CurrentPost.UserId == (int)HttpContext.Session.GetInt32("userID"))//the post which I have created by fowwing the delete route (security perpose)
            {

            Idea deleteidea = _context.ideas.SingleOrDefault(i => i.IdeaId == id);

            _context.Remove(deleteidea);
            _context.SaveChanges();
            return RedirectToAction("brightideas");
            }
            else{
                return RedirectToAction("Index");
            }
        }

        [Route("usersprofile/{id}")]

        public IActionResult usersprofile(int id){

            ViewBag.usersprofile = _context.users.Include(I => I.userpostidealist).Include(L => L.userlikeidealist).SingleOrDefault(d => d.UserId == id);
            return View();
        }
        [Route("LikeStatus/{id}")]

        public IActionResult LikeStatus(int id){

            ViewBag.idea = _context.ideas.Include(u => u.User).Include(l => l.peopleslike).ThenInclude(u => u.User).SingleOrDefault(u => u.IdeaId == id);

            return View();
        }

        [Route("dashboardbutton")]
        public IActionResult dashboardbutton()
        {
            return RedirectToAction("brightideas");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
