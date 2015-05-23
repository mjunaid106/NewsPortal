using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Interfaces;

namespace NewsPortal.Domain.Test.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly IList<User> _users;
        public FakeUserRepository(IList<User> users)
        {
            _users = users;
        }
        public IList<User> ReadAll()
        {
            return _users;
        }

        public User Read(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
