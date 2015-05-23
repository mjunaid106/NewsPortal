using System.Collections.Generic;
using NewsPortal.Data.Entities;
using NewsPortal.Domain.Responses;

namespace NewsPortal.Domain.Interfaces
{
    public interface IArticleManager
    {
        ArticlePublishResponse Publish(User publisher, Article article);

        ArticlePublishResponse LikeArticle(User user, Article article);

        IList<Article> ListTopArticles();

        Article GetArticle(int id);
    }
}
