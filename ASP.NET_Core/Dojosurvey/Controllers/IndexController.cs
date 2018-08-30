using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Dojosurvey.Controllers
{
    public class IndexController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        
        [HttpPost]
        [Route("submit")]
        public IActionResult submit(string name, string location,string language,string comment)
        {

            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment; 
            return View("result");
        }
    }
}

