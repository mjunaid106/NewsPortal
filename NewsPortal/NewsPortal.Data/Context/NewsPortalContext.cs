using System.Data.Entity;
using NewsPortal.Data.Entities;

namespace NewsPortal.Data.Context
{
    public class NewsPortalContext : DbContext, INewsPortalContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Article> Articles { get; set; }
        
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
