using JobHubWebAPI.APPLICATIONLAYER.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHubWebAPI.Controllers
{
    [Authorize]
    public class AccoutController : Controller
    {
        private readonly IAccountService accountService;

        public AccoutController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpGet]
        [Route("/acc")]
        public ActionResult UploadAccount()
        {
            var user = HttpContext.User.FindFirst("UserId"); // UserId Claim added when User Registered 
            if(user == null)
            {
                return Unauthorized();
            }
            return Ok(accountService.UploadUsersInformation(user.ToString()));
        }
        [HttpGet]
        [Route("/acc/edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount()
        {
            var user = HttpContext.User.FindFirst("UserId"); 
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(accountService.UploadUserInformationForEdit(user.ToString()));
        }
    }
}
