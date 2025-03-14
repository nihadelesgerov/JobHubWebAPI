using JobHubWebAPI.ApplicationLayer.AuthService.Implementations;
using JobHubWebAPI.ApplicationLayer.AuthService.Interfaces;
using JobHubWebAPI.ApplicationLayer.Token;
using JobHubWebAPI.DataLayer.AuthModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHubWebAPI.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterService authService;
        private readonly ILoginService loginService;
        private readonly LogOutService logOutService;

        public AuthController(IRegisterService authService,ILoginService loginService, LogOutService logOutService)
        {
            this.authService = authService;
            this.loginService = loginService;
            this.logOutService = logOutService;
        }

        [HttpPost,Route("/reg")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model )
        {
            // Didn't add email sender to confirm it (small project tho)
          var (accesToken,RefreshToken) =  await  authService.RegisterUserAsync(model.Password, model.Email);
            return Ok( new {AccesToken = accesToken,RefreshToken= RefreshToken});
        }

        [HttpPost, Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
         var(accesToken,refreshToken)  =  await loginService.LoginUserAsync(model.Email, model.Password);
            return Ok(new {AccesToken = accesToken,RefreshToken = refreshToken});
        }

        [HttpPost]
        [Route("/logOut")]
        public async Task<ActionResult> Logout()
        {
                var userId = User.FindFirst("UserId")?.Value; // when user registered I added user's claim with claim type ""UserId" , now Im looking for it to get user
            if (userId == null) return Unauthorized();
                await logOutService.LogoutUserAsync(userId);
                return Ok(new { Message = "Logged out successfully" });
        }
    }
}
