using System;
using System.Collections.Generic;
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

        public DataWriteResult Create(Article article)
        {
            try
            {
                _context.Articles.Add(article);
                _context.SaveChanges();
                return DataWriteResult.SuccessResult();
            }
            catch (Exception exception)
            {
                return DataWriteResult.FailureResult(exception);
            }
        }

        public DataWriteResult Update(Article article)
        {
            try
            {
                _context.Articles.Attach(article);
                _context.SaveChanges();
                return DataWriteResult.SuccessResult();
            }
            catch (Exception exception)
            {
                return DataWriteResult.FailureResult(exception);
            }
        }

        public DataWriteResult Delete(Article article)
        {
            try
            {
                _context.Articles.Remove(article);
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
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }

        public IList<Article> ReadAll()
        {
            return _context.Articles.ToList();
        }

        public IList<Article> ReadByType(ArticleType type)
        {
            return _context.Articles.Where(a => a.ArticleType == type).ToList();
        }
    }
}
