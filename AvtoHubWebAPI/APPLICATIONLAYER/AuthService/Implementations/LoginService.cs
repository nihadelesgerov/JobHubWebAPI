using Azure.Core;
using JobHubWebAPI.ApplicationLayer.AuthService.Interfaces;
using JobHubWebAPI.ApplicationLayer.Token;
using JobHubWebAPI.DataLayer.DataBaseConnection;
using Microsoft.AspNetCore.Identity;

namespace JobHubWebAPI.ApplicationLayer.AuthService.Repos
{
    public class LoginService : ILoginService
    {
        private readonly GenJWT tokenService;
        private readonly UserManager<AppUser> userManager;

        public LoginService(GenJWT tokenService,UserManager<AppUser> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
        }
        public async Task<(string AccessToken, string RefreshToken)> LoginUserAsync(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null || await userManager.CheckPasswordAsync(user, password)) // if user is null or it's email or password are incorrect
            {
                throw new UnauthorizedAccessException("Invalid Email or Password");
            }
            var accesToken = tokenService.GenerateAccesToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            await userManager.UpdateAsync(user);

            return (accesToken, refreshToken);

        }

    }
}
