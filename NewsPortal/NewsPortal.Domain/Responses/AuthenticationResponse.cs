using System.Security.AccessControl;
using NewsPortal.Data.Entities;
using NewsPortal.Domain.Enums;

namespace NewsPortal.Domain.Responses
{
    public class AuthenticationResponse : ResponseBase
    {
        public LoginResponseType ResponseType { get; set; }
        public User LoggedInUser { get; set; }

        public static AuthenticationResponse InvalidLogin(LoginResponseType responseType)
        {
            return new AuthenticationResponse { Success = false, ResponseType = responseType };
        }

        public static AuthenticationResponse SuccessfulLogin(User user)
        {
            return new AuthenticationResponse { Success = true, ResponseType = LoginResponseType.Success, LoggedInUser = user };
        }
    }
}
