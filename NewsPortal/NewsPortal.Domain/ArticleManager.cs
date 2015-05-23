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
    }
}
