using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
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
        public Author Author { get; set; }
        [Required]
        public ArticleType ArticleType { get; set; }
        [Required]
        public User Publisher { get; set; }

        public int Likes { get; set; }
    }
}
