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
        private readonly IList<Author> _authors;

        public FakeArticleRepository(IList<Article> articles, IList<Author> authors)
        {
            _articles = articles;
            _authors = authors;
        }

        public DataWriteResult Create(User publisher, Article article)
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

        public DataWriteResult Update(User publisher, Article article)
        {
            throw new NotImplementedException();
        }

        public DataWriteResult Delete(User publisher, Article article)
        {
            throw new NotImplementedException();
        }

        public Article Read(int id)
        {
            return _articles.FirstOrDefault(a => a.Id == id);
        }

        public IList<Article> ReadAll()
        {
            return _articles;
        }

        public IList<Article> ReadByType(ArticleType type)
        {
            return _articles.Where(a => a.ArticleType == type).ToList();
        }

        public DataWriteResult Like(User user, Article article)
        {
            DataWriteResult response;
            if (user.Likes > 0)
            {
                article.Likes += 1;
                user.Likes -= 1;
                response = DataWriteResult.SuccessResult();
            }
            else
            {
                response = DataWriteResult.FailureResult(new Exception("Insufficient likes remaining"));
            }
            return response;
        }

        public IList<Author> GetAllAuthors()
        {
            return _authors.ToList();
        }
    }
}
