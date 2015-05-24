using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsPortal.Domain.Enums;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;

namespace NewsPortal.Web.Api.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthentication _authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        [HttpPost, Route("login/{username:alpha}/{password:alpha}")]
        public HttpResponseMessage Login(string username, string password)
        {
            AuthenticationResponse result = _authentication.IsUserAuthenticated(username, password);
            HttpResponseMessage response;
            if (result.Success)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, result.LoggedInUser);
            }
            else 
            {
                response = result.ResponseType == LoginResponseType.InvalidUsername ?
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "InvalidUsername") : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InvalidPassword");

            }
            return response;
        }
    }
}
