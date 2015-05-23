using System;
using System.Linq;
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

        [TestInitialize]
        public void Initilise()
        {

            _context = new NewsPortalContext();
            _articleRepository = new ArticleRepository(_context);
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
            Assert.IsNull(articles);
        }

        //[TestMethod]
        //public void Create_Successful()
        //{
        //    var article = new Article
        //    {
        //        Title = "First Sports Article",
        //        Author = _context.Users.First(),
        //        Body = "Text for article",
        //        PublishDate = DateTime.Now,
        //        ArticleType = ArticleType.Sports
        //    };
        //    DataWriteResult result = _articleRepository.Create(article);
        //    Assert.AreEqual(true, result.Success);
        //}
    }
}
