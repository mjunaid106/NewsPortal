using NewsPortal.Domain.Enums;

namespace NewsPortal.Domain.Responses
{
    public class AuthenticationResponse: ResponseBase
    {
        public LoginResponseType ResponseType { get; set; }

        public static AuthenticationResponse InvalidLogin(LoginResponseType responseType)
        {
            return new AuthenticationResponse { Success = false, ResponseType = responseType };
        }

        public static AuthenticationResponse SuccessfulLogin()
        {
            return new AuthenticationResponse { Success = true, ResponseType = LoginResponseType.Success };
        }
    }
}
