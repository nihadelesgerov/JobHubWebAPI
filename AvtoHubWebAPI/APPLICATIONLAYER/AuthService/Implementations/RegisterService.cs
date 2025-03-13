using JobHubWebAPI.ApplicationLayer.AuthService.Interfaces;
using JobHubWebAPI.ApplicationLayer.Token;
using JobHubWebAPI.DataLayer.DataBaseConnection;
using Microsoft.AspNetCore.Identity;

namespace JobHubWebAPI.ApplicationLayer.AuthService.Repos
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly GenJWT tokenService;

        public RegisterService(UserManager<AppUser> userManager,GenJWT tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }
        public async  Task<(string AccessToken, string RefreshToken)> RegisterUserAsync(string email, string password)
        {
            var user = new AppUser  
            {
                Email = email,
                UserName = email,
            };
            var result = userManager.CreateAsync(user, password);
            var accesToken = tokenService.GenerateAccesToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            await userManager.UpdateAsync(user); // updates refreshtoken prop of AppUser 
            return (accesToken, refreshToken);
        }
    }
}
