using System.Data.Entity;
using NewsPortal.Data.Entities;

namespace NewsPortal.Data.Context
{
    public interface INewsPortalContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Article> Articles { get; set; }

        void SaveChanges();
    }
}
