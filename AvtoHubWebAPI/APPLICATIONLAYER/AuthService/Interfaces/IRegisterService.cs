namespace JobHubWebAPI.ApplicationLayer.AuthService.Interfaces
{
    public interface IRegisterService
    {
        Task<(string AccessToken, string RefreshToken)> RegisterUserAsync(string email, string password);
    }
}
