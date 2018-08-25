using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using view_model_fun.Models;
namespace view_model_fun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            string msg = "some message here longer longer";
            return View("Home",msg);    
        }

        [HttpGet]
        [Route("user")]
        public IActionResult UserDetail()
        {
        User user = new User()
        {
            FirstName = "Devon",
            LastName = "Newsom"
        };
        
        return View("user", user);
        }
        [HttpGet]
        [Route("users")]
        public IActionResult Names()
        {
            string[] names = new string[]
            {
            "Sally", "Billy", "Joey", "Moose"
            };
            return View("users",names);
        }
        [HttpGet]
        [Route("number")]
        public IActionResult number()
        {
           List<int> num = new List<int>();
           num.Add(1);
           num.Add(4);
           num.Add(5);
           num.Add(10);
           num.Add(15);
           num.Add(20);

            return View("number",num);
        }


        

    }
}
