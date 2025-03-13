using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHubWebAPI.Controllers
{
    [Authorize]
    public class AccoutController : Controller
    {
        public AccoutController()
        {

        }

        [HttpGet, Route("/acc")]
        public ActionResult MyAccount()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.Email);
            if (user == null)
            {
                return Unauthorized((new {Message = "User didn't log in"}));
            }

        }

            // load account
            // add info about company
            //show jobs (if have)
            // create jobs
        }
}
