using NewsPortal.Data.Entities;
using NewsPortal.Data.Interfaces;
using NewsPortal.Domain.Enums;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;

namespace NewsPortal.Domain.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly IUserRepository _userRepository;

        public Authentication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthenticationResponse IsUserAuthenticated(string username, string password)
        {
            AuthenticationResponse response;
            User user = _userRepository.Read(username);
            if (user == null)
            {
                response = AuthenticationResponse.InvalidLogin(ResponseType.InvalidUsername);
            }
            else if (!user.Password.Equals(password))
            {
                response = AuthenticationResponse.InvalidLogin(ResponseType.InvalidPassword);
            }
            else
            {
                response = AuthenticationResponse.SuccessfulLogin();
            }
            return response;
        }
    }
}
