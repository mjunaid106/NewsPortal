using System;
using NewsPortal.Data.Enums;

namespace NewsPortal.Data.Entities
{
    public class Article : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public User Author { get; set; }

        public ArticleType ArticleType { get; set; }
    }
}
