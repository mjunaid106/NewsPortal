using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Interfaces;
using NewsPortal.Domain.Enums;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;
using NewsPortal.Domain.Test.Fakes;

namespace NewsPortal.Domain.Test.AuthenticationTests
{
    [TestClass]
    public class AuthenticationTests
    {
        private IAuthentication _authentication;

        [TestInitialize]
        public void Initilise()
        {
            IList<User> users = new List<User>
            {
                new User { Id = 1, Username = "FakeUser1", Name = "Fake User 1", Password = "password", Role = Role.Publisher },
                new User { Id = 2, Username = "FakeUser2", Name = "Fake User 2", Password = "password", Role = Role.Employee }
            };
            IUserRepository userRepository = new FakeUserRepository(users);
            _authentication = new Authentication.Authentication(userRepository);
        }

        [TestMethod]
        public void Login_Successful()
        {
            AuthenticationResponse response = _authentication.IsUserAuthenticated("FakeUser1", "password");
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(LoginResponseType.Success, response.ResponseType);
        }

        [TestMethod]
        public void Login_WrongUsername()
        {
            AuthenticationResponse response = _authentication.IsUserAuthenticated("FakeUser11", "password");
            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(LoginResponseType.InvalidUsername, response.ResponseType);
        }

        [TestMethod]
        public void Login_WrongPassword()
        {
            AuthenticationResponse response = _authentication.IsUserAuthenticated("FakeUser1", "password1");
            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(LoginResponseType.InvalidPassword, response.ResponseType);
        }
    }


}
