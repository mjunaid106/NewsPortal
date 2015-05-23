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
        private Author _author;
        private User _publisher;
        private User _employee;

        [TestInitialize]
        public void Initilise()
        {

            _author = new Author
            {
                Id = 1,
                Name = "Fake Author 1"
            };

            _publisher = new User
            {
                Id = 1,
                Username = "FakePublisher1",
                Name = "Fake Publisher 1",
                Password = "password",
                Role = Role.Publisher
            };

            _employee = new User
            {
                Id = 1,
                Username = "FakeEmployee1",
                Name = "Fake Employee 1",
                Password = "password",
                Role = Role.Employee,
                Likes = 10
            };

            var articles = new List<Article>
            {
                new Article { Id = 1, Title = "News Article 1", Author = _author, Body = "This is a sample body for News Article 1", ArticleType = ArticleType.News, PublishDate = DateTime.Now },
                new Article { Id = 2, Title = "News Article 2", Author = _author, Body = "This is a sample body for News Article 2", ArticleType = ArticleType.News, PublishDate = DateTime.Now },
                new Article { Id = 3, Title = "Technology Article 1", Author = _author, Body = "This is a sample body for Technology Article 1", ArticleType = ArticleType.Technology, PublishDate = DateTime.Now }
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
                Author = _author,
                Body = "This is a new sport article",
                ArticleType = ArticleType.Sports,
                PublishDate = DateTime.Now
            };
            ArticlePublishResponse response = _articleManager.Publish(_publisher, article);
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
            ArticlePublishResponse response = _articleManager.Publish(_publisher, article);
            Assert.AreEqual(false, response.Success);
        }

        [TestMethod]
        public void LikeArticle_Successful()
        {
            var article = new Article
            {
                Title = "Sports Article",
                Author = _author,
                Body = "This is a new sport article",
                ArticleType = ArticleType.Sports,
                PublishDate = DateTime.Now,
                Likes = 5
            };
            ArticlePublishResponse response = _articleManager.LikeArticle(_employee, article);
            Assert.AreEqual(true, response.Success);
            Assert.AreEqual(9, _employee.Likes);
            Assert.AreEqual(6, article.Likes);
        }

        [TestMethod]
        public void LikeArticle_InsufficientLikes_Successful()
        {
            _employee.Likes = 0;
            var article = new Article
            {
                Title = "Sports Article",
                Author = _author,
                Body = "This is a new sport article",
                ArticleType = ArticleType.Sports,
                PublishDate = DateTime.Now,
                Likes = 5
            };
            ArticlePublishResponse response = _articleManager.LikeArticle(_employee, article);
            Assert.AreEqual(false, response.Success);
            Assert.AreEqual(5, article.Likes);
        }
    }
}
