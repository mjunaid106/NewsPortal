using NewsPortal.Data.Context;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;

namespace NewsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsPortal.Data.Context.NewsPortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            var context = new NewsPortalContext();
            Seed(context);
        }

        protected override void Seed(NewsPortalContext context)
        {
            // Add Users
            context.Users.AddOrUpdate(
                new User { Id = 1, Username = "Publisher1", Name = "Publisher 1", Password = "password", Role = Role.Publisher },
                new User { Id = 2, Username = "Publisher2", Name = "Publisher 2", Password = "password", Role = Role.Publisher },
                new User { Id = 3, Username = "Publisher3", Name = "Publisher 3", Password = "password", Role = Role.Publisher },
                new User { Id = 4, Username = "Publisher4", Name = "Publisher 4", Password = "password", Role = Role.Publisher },
                new User { Id = 5, Username = "Employee1", Name = "Employee 1", Password = "password", Role = Role.Employee },
                new User { Id = 6, Username = "Employee2", Name = "Employee 2", Password = "password", Role = Role.Employee },
                new User { Id = 7, Username = "Employee3", Name = "Employee 3", Password = "password", Role = Role.Employee },
                new User { Id = 8, Username = "Employee4", Name = "Employee 4", Password = "password", Role = Role.Employee }
                );
            context.SaveChanges();

            // Add Users
            context.Authors.AddOrUpdate(
                new Author { Id = 1, Name = "Author 1" },
                new Author { Id = 2, Name = "Author 2" },
                new Author { Id = 3, Name = "Author 3" }
                );
            context.SaveChanges();

            User publisher = context.Users.First(u => u.Id == 1);
            Author author = context.Authors.First(u => u.Id == 1);
            // Add Articles
            context.Articles.AddOrUpdate(
                new Article { Id = 1, Title = "News Article 1", Author = author, Publisher = publisher, Body = "This is a sample body for News Article 1", ArticleType = ArticleType.News, PublishDate = DateTime.Now },
                new Article { Id = 2, Title = "News Article 2", Author = author, Publisher = publisher, Body = "This is a sample body for News Article 2", ArticleType = ArticleType.News, PublishDate = DateTime.Now },
                new Article { Id = 3, Title = "Technology Article 1", Author = author, Publisher = publisher, Body = "This is a sample body for Technology Article 1", ArticleType = ArticleType.Technology, PublishDate = DateTime.Now }
                );
            context.SaveChanges();
        }
    }
}
