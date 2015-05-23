using System.Collections.Generic;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Results;

namespace NewsPortal.Data.Interfaces
{
    public interface IArticleRepository
    {
        DataWriteResult Create(Article article);
        DataWriteResult Update(Article article);
        DataWriteResult Delete(Article article);
        Article Read(int id);
        IList<Article> ReadAll();
        IList<Article> ReadByType(ArticleType type);
    }
}
