using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Results;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;

namespace NewsPortal.Domain
{
    public class ArticleManager : IArticleManager
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ArticlePublishResponse Publish(User publisher, Article article)
        {
            DataWriteResult result = _articleRepository.Create(publisher, article);

            ArticlePublishResponse response = result.Success ? ResponseBase.SuccessResponse() : ResponseBase.FailureResponse();
            return response;
        }

        public ArticlePublishResponse LikeArticle(User user, Article article)
        {
            DataWriteResult result = _articleRepository.Like(user, article);

            ArticlePublishResponse response = result.Success ? ResponseBase.SuccessResponse() : ResponseBase.FailureResponse();
            return response;
        }

        public IList<Article> ListTopArticles()
        {
            return _articleRepository.ReadAll().OrderByDescending(l => l.Likes).Take(10).ToList();
        }

        public Article GetArticle(int id)
        {
            return _articleRepository.Read(id);
        }

        public IList<Author> GetAllAuthors()
        {
            return _articleRepository.GetAllAuthors();
        }

        public IList<Article> GetArticleStats()
        {
            return _articleRepository.ReadAll().ToList();
        }
    }
}
