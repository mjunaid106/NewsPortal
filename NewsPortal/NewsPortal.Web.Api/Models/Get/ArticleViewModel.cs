using System;
using NewsPortal.Data.Enums;

namespace NewsPortal.Web.Api.Models.Get
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public AuthorViewModel Author { get; set; }
        public ArticleType ArticleType { get; set; }
        public UserViewModel Publisher { get; set; }
        public int Likes { get; set; }
    }
}