    using Microsoft.AspNetCore.Mvc;
    namespace portfolio_1.Controllers     //be sure to use your own project's namespace!
    {
        public class HelloController : Controller   //remember inheritance??
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public string Index()
            {
                return "This is my Index";
            }
             [HttpGet]       //type of request
            [Route("projects")]     //associated route string (exclude the leading /)
            public string projects()
            {
                return "I have done some projects";
            }
             [HttpGet]       //type of request
            [Route("contact")]     //associated route string (exclude the leading /)
            public string contact()
            {
                return "This is my contact";
            }
        }
    }
