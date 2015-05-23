using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Data.Context;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Repository;

namespace NewsPortal.Data.Test.Integration.Repository
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [TestInitialize]
        public void Initilise()
        {
            INewsPortalContext context = new NewsPortalContext();
            _userRepository = new UserRepository(context);
        }

        [TestMethod]
        public void ReadAll_Successful()
        {
            var users = _userRepository.ReadAll();
            Assert.AreEqual(8, users.Count);
        }

        [TestMethod]
        public void Read_UserExists_Successful()
        {
            const string username = "Publisher1";
            var user = _userRepository.Read(username);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Read_UserDoesNotExist_Successful()
        {
            const string username = "Publisher";
            var user = _userRepository.Read(username);
            Assert.IsNull(user);
        }
    }
}
