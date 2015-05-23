using System;
using System.Collections;
using System.Collections.Generic;
using NewsPortal.Data.Enums;

namespace NewsPortal.Web.Models.NewArticleViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime PublishDate { get; set; }
        public AuthorViewModel Author { get; set; }
        public ArticleType ArticleType { get; set; }
        public int Likes { get; set; }

        public IList<AuthorViewModel> Authors { get; set; }

        public IList<ArticleStatsViewMode> ArticleStats { get; set; }
    }

    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ArticleStatsViewMode
    {
        public string Title { get; set; }
        public int Likes { get; set; }
    }

    
}