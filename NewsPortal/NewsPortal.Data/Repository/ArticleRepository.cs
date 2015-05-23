using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using NewsPortal.Data.Context;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Results;

namespace NewsPortal.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly INewsPortalContext _context;

        public ArticleRepository(INewsPortalContext context)
        {
            _context = context;
        }

        public DataWriteResult Create(User publisher, Article article)
        {
            try
            {
                User dbPublisher = _context.Users.First(u => u.Id == publisher.Id && u.Role == Role.Publisher);
                article.Publisher = dbPublisher;
                _context.Articles.Add(article);
                _context.SaveChanges();
                return DataWriteResult.SuccessResult();
            }
            catch (Exception exception)
            {
                return DataWriteResult.FailureResult(exception);
            }
        }

        public DataWriteResult Update(User publisher, Article article)
        {
            try
            {
                User dbPublisher = _context.Users.First(u => u.Id == publisher.Id && u.Role == Role.Publisher);
                article.Publisher = dbPublisher;
                _context.Articles.Attach(article);
                _context.SaveChanges();
                return DataWriteResult.SuccessResult();
            }
            catch (Exception exception)
            {
                return DataWriteResult.FailureResult(exception);
            }
        }

        public DataWriteResult Delete(User publisher, Article article)
        {
            try
            {
                User dbPublisher = _context.Users.First(u => u.Id == publisher.Id && u.Role == Role.Publisher);
                Article dbArticle = _context.Articles.FirstOrDefault(a => a.Id == article.Id);
                _context.Articles.Remove(dbArticle);
                _context.SaveChanges();
                return DataWriteResult.SuccessResult();
            }
            catch (Exception exception)
            {
                return DataWriteResult.FailureResult(exception);
            }
        }

        public Article Read(int id)
        {
            return _context.Articles.Include(a=>a.Author).Include(p=>p.Publisher).FirstOrDefault(a => a.Id == id);
        }

        public IList<Article> ReadAll()
        {
            return _context.Articles.Include(a => a.Author).Include(p => p.Publisher).ToList();
        }

        public IList<Article> ReadByType(ArticleType type)
        {
            return _context.Articles.Include(a => a.Author).Include(p => p.Publisher).Where(a => a.ArticleType == type).ToList();
        }

        public DataWriteResult Like(User user, Article article)
        {
            try
            {
                if (user.Likes > 0)
                {
                    //var articleDb = _context.Articles.First(a => a.Id == article.Id);
                    //var userDb = _context.Users.First(u => u.Id == user.Id);
                    //articleDb.Likes += 1;
                    //userDb.Likes -= 1;
                    _context.Users.Attach(user);
                   // _context.Entry(user).Property(x => x.Password).IsModified = true;
                    _context.SaveChanges();
                    return DataWriteResult.SuccessResult();
                }
                return DataWriteResult.FailureResult(new Exception("Insufficient likes remaining"));
            }
            catch (Exception exception)
            {
                return DataWriteResult.FailureResult(exception);
            }
        }
    }
}
