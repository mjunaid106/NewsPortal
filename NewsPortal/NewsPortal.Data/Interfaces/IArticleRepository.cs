using System.Collections.Generic;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Results;

namespace NewsPortal.Data.Interfaces
{
    public interface IArticleRepository
    {
        DataWriteResult Create(User publisher, Article article);
        DataWriteResult Update(User publisher, Article article);
        DataWriteResult Delete(User publisher, Article article);
        Article Read(int id);
        IList<Article> ReadAll();
        IList<Article> ReadByType(ArticleType type);

        DataWriteResult Like(User user, Article article);

        IList<Author> GetAllAuthors();
    }
}
