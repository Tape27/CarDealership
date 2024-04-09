namespace Dealership.Services.Interface.Admin
{
    public interface IAdminAuthenticationService
    {
        Task<bool> AuthenticationAsync(string login, string password);
        bool IsAuthenticatedAsync();
        Task LogoutAsync();
    }
}
