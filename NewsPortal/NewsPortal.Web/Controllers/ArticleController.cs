using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using NewsPortal.Data.Entities;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;
using NewsPortal.Web.Models;
using NewsPortal.Web.Models.ArticleViewModels;

namespace NewsPortal.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleManager _articleManager;

        public ArticleController(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }
        // GET: Article
        public ActionResult Index(int id)
        {
            var article = Mapper.Map<ArticleDetailViewModel>(_articleManager.GetArticle(id));
            return View(article);
        }
        // GET: Article
        [HttpPost]
        public ActionResult Like(int id)
        {
            var user = (User)Session["LoggedInUser"];
            var article = new Article() { Id = id };
            ArticlePublishResponse response = _articleManager.LikeArticle(user, article);
            return Json(response.Success);
        }
    }
}