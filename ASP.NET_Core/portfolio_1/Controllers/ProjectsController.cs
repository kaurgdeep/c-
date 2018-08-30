using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace portfolio_1.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            // return View();
            //OR
            return View("Projects");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}