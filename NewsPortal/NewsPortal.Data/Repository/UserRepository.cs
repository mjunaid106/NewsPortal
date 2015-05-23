using System;
using System.Collections.Generic;
using System.Linq;
using NewsPortal.Data.Context;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Entities;

namespace NewsPortal.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly INewsPortalContext _context;

        public UserRepository(INewsPortalContext context)
        {
            _context = context;
        }

        public IList<User> ReadAll()
        {
            return _context.Users.ToList();
        }

        public User Read(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
