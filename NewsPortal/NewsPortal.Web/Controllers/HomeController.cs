using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NewsPortal.Data.Entities;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Web.Models;

namespace NewsPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleManager _articleManager;

        public HomeController(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }

        public ActionResult Index()
        {
            IList<ListArticlesViewModel> viewModel = Mapper.Map<IList<Article>, IList<ListArticlesViewModel>>(_articleManager.ListTopArticles());
            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}