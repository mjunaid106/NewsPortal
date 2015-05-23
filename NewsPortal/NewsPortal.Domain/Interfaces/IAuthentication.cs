using NewsPortal.Domain.Responses;

namespace NewsPortal.Domain.Interfaces
{
    public interface IAuthentication
    {
        AuthenticationResponse IsUserAuthenticated(string username, string password);
    }
}
