using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace portfolio_1.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            // return View();
            //OR
            return View("Contact");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}