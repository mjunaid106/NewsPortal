using System;

namespace NewsPortal.Web.Models
{
    public class ListArticlesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public int Likes { get; set; }
    }
}