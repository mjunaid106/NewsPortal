using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Results;

namespace NewsPortal.Domain.Test.Fakes
{
    public class FakeArticleRepository : IArticleRepository
    {
        private readonly IList<Article> _articles;

        public FakeArticleRepository(IList<Article> articles)
        {
            _articles = articles;
        }

        public DataWriteResult Create(Article article)
        {
            DataWriteResult response;
            if (article.Author == null)
            {
                response = DataWriteResult.FailureResult(new Exception("Authour null"));
            }
            else
            {
                _articles.Add(article);
                response = DataWriteResult.SuccessResult();
            }
            _articles.Add(article);
            return response;
        }

        public DataWriteResult Update(Article article)
        {
            throw new NotImplementedException();
        }

        public DataWriteResult Delete(Article article)
        {
            throw new NotImplementedException();
        }

        public Article Read(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Article> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IList<Article> ReadByType(ArticleType type)
        {
            throw new NotImplementedException();
        }
    }
}
