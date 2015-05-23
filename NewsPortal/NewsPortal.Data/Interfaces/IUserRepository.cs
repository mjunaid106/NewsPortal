using System.Collections.Generic;
using NewsPortal.Data.Entities;

namespace NewsPortal.Data.Interfaces
{
    public interface IUserRepository
    {
        IList<User> ReadAll();
        User Read(string username);
    }
}
