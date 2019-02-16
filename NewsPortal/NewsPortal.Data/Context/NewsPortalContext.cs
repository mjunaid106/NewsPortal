using System.Data.Entity;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Migrations;

namespace NewsPortal.Data.Context
{
    public class NewsPortalContext : DbContext, INewsPortalContext
    {
        public NewsPortalContext(): base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsPortalContext, Configuration>());
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Article> Articles { get; set; }
        
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
