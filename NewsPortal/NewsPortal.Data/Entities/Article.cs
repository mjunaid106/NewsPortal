using System;
using System.ComponentModel.DataAnnotations;
using NewsPortal.Data.Enums;

namespace NewsPortal.Data.Entities
{
    public class Article : Entity
    {
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public ArticleType ArticleType { get; set; }
    }
}
