using NewsPortal.Data.Entities;
using NewsPortal.Domain.Responses;

namespace NewsPortal.Domain.Interfaces
{
    public interface IArticleManager
    {
        ArticlePublishResponse Publish(Article article);
    }
}
