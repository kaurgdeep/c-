using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace portfolio_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            ViewBag.name = "Gagandeep";
            // return View();
            //OR
            return View("Home");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}
    