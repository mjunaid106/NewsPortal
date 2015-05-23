using System;
using NewsPortal.Data.Entities;
using NewsPortal.Data.Enums;

namespace NewsPortal.Web.Models.ArticleViewModels
{
    public class ArticleDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime PublishDate { get; set; }
        public AuthorViewModel Author { get; set; }
        public ArticleType ArticleType { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public int Likes { get; set; }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
    }

    public class PublisherViewModel
    {
        public string Name { get; set; }
    }
}