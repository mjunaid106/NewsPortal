using NewsPortal.Domain.Enums;

namespace NewsPortal.Domain.Responses
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public ResponseType ResponseType { get; set; }

        public static AuthenticationResponse InvalidLogin(ResponseType responseType)
        {
            return new AuthenticationResponse { Success = false, ResponseType = responseType };
        }

        public static AuthenticationResponse SuccessfulLogin()
        {
            return new AuthenticationResponse { Success = true, ResponseType = ResponseType.Success };
        }
    }
}
