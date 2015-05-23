using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Interfaces;
using NewsPortal.Domain.Responses;
using NewsPortal.Domain.Test.Fakes;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain;

namespace NewsPortal.Domain.Test.ArticleTests
{
    [TestClass]
    public class ArticleTests
    {
        private IArticleManager _articleManager;
        private User _user;

        [TestInitialize]
        public void Initilise()
        {

            _user = new User
            {
                Id = 1,
                Username = "FakeUser1",
                Name = "Fake User 1",
                Password = "password",
                Role = Role.Publisher
            };

            var articles = new List<Article>
            {
                new Article { Id = 1, Title = "News Article 1", Author = _user, Body = "This is a sample body for News Article 1", ArticleType = ArticleType.News, PublishDate = DateTime.Now },
                new Article { Id = 2, Title = "News Article 2", Author = _user, Body = "This is a sample body for News Article 2", ArticleType = ArticleType.News, PublishDate = DateTime.Now },
                new Article { Id = 3, Title = "Technology Article 1", Author = _user, Body = "This is a sample body for Technology Article 1", ArticleType = ArticleType.Technology, PublishDate = DateTime.Now }
            };
            IArticleRepository articleRepository = new FakeArticleRepository(articles);
            _articleManager = new ArticleManager(articleRepository);
        }
       
        [TestMethod]
        public void PublishArticle_Successful()
        {
            var article = new Article
            {
                Title = "Sports Article",
                Author = _user,
                Body = "This is a new sport article",
                ArticleType = ArticleType.Sports,
                PublishDate = DateTime.Now
            };
            ArticlePublishResponse response = _articleManager.Publish(article);
            Assert.AreEqual(true, response.Success);
        }

        [TestMethod]
        public void PublishArticle_NoUser_Failure()
        {
            var article = new Article
            {
                Title = "Sports Article",
                Body = "This is a new sport article",
                ArticleType = ArticleType.Sports,
                PublishDate = DateTime.Now
            };
            ArticlePublishResponse response = _articleManager.Publish(article);
            Assert.AreEqual(false, response.Success);
        }
    }
}
