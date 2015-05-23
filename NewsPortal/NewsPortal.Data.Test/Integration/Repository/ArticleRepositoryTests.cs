using System;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Data.Context;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Repository;
using NewsPortal.Data.Results;

namespace NewsPortal.Data.Test.Integration.Repository
{
    [TestClass]
    public class ArticleRepositoryTests
    {
        INewsPortalContext _context;
        private IArticleRepository _articleRepository;
        private User publisher;

        [TestInitialize]
        public void Initilise()
        {

            _context = new NewsPortalContext();
            _articleRepository = new ArticleRepository(_context);
            publisher = _context.Users.Skip(1).First(u => u.Role == Role.Publisher);
        }

        [TestMethod]
        public void Create_Successful()
        {
            var article = new Article
            {
                Title = "First Sports Article",
                Author = _context.Authors.First(),
                Body = "Text for article",
                PublishDate = DateTime.Now,
                ArticleType = ArticleType.Sports
            };

            using (new TransactionScope(TransactionScopeOption.Required, TimeSpan.MaxValue))
            {
                DataWriteResult result = _articleRepository.Create(publisher, article);
                Assert.AreEqual(true, result.Success);
                Assert.IsNull(result.Exception);
            }
        }

        [TestMethod]
        public void Create_Exception()
        {
            var article = new Article
            {
                Title = "First Sports Article",
                Body = "Text for article",
                PublishDate = DateTime.Now,
                ArticleType = ArticleType.Sports
            };

            using (new TransactionScope(TransactionScopeOption.Required, TimeSpan.MaxValue))
            {
                DataWriteResult result = _articleRepository.Create(publisher, article);
                Assert.AreEqual(false, result.Success);
                Assert.IsNotNull(result.Exception);
            }
        }

        [TestMethod]
        public void Update_Successful()
        {
            var article = new Article
            {
                Id = 2,
                Title = "Changed to Sports Article",
                Author = _context.Authors.First(),
                Body = "Now a sports article",
                PublishDate = DateTime.Now,
                ArticleType = ArticleType.Sports
            };

            using (new TransactionScope(TransactionScopeOption.Required, TimeSpan.MaxValue))
            {
                DataWriteResult result = _articleRepository.Update(publisher, article);
                Assert.AreEqual(true, result.Success);
                Assert.IsNull(result.Exception);
            }
        }

        [TestMethod]
        public void Delete_Successful()
        {
            var article = new Article
            {
                Id = 3
            };
            using (new TransactionScope(TransactionScopeOption.Required, TimeSpan.MaxValue))
            {
                DataWriteResult result = _articleRepository.Delete(publisher, article);
                Assert.AreEqual(true, result.Success);
                Assert.IsNull(result.Exception);
            }
        }

        [TestMethod]
        public void ReadAll_Successful()
        {
            var articles = _articleRepository.ReadAll();
            Assert.AreEqual(3, articles.Count);
        }

        [TestMethod]
        public void Read_ArticleExists_Successful()
        {
            var article = _articleRepository.Read(1);
            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void Read_ArticleDoesNotExists_Successful()
        {
            var article = _articleRepository.Read(10);
            Assert.IsNull(article);
        }

        [TestMethod]
        public void ReadByType_ArticleExists_Successful()
        {
            var articles = _articleRepository.ReadByType(ArticleType.News);
            Assert.AreEqual(2, articles.Count);
        }

        [TestMethod]
        public void ReadByType_ArticleDoesNotExists_Successful()
        {
            var articles = _articleRepository.ReadByType(ArticleType.Sports);
            Assert.AreEqual(0, articles.Count);
        }
    }
}
