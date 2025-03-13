using JobHubWebAPI.DataLayer.DataBaseConnection;
using Microsoft.AspNetCore.Identity;

namespace JobHubWebAPI.ApplicationLayer.AuthService.Implementations
{
    public class LogOutService
    {
        private readonly UserManager<AppUser> userManager;

        public LogOutService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task LogoutUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) throw new Exception("User not found");
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
        }
    }
}
