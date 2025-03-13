namespace JobHubWebAPI.ApplicationLayer.AuthService.Interfaces
{
    public interface ILoginService
    {
        Task<(string AccessToken, string RefreshToken)> LoginUserAsync(string email, string password);
    }
}
