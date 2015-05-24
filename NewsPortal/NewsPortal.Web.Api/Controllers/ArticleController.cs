using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NewsPortal.Domain.Interfaces;
using NewsPortal.Domain.Responses;
using NewsPortal.Web.Api.Models.Get;
using NewsPortal.Data.Entities;

namespace NewsPortal.Web.Api.Controllers
{
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        private readonly IArticleManager _articleManager;

        public ArticleController(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }

        [HttpGet, Route("get/{articleId:int}")]
        public HttpResponseMessage Get(int articleId)
        {
            var article = Mapper.Map<ArticleViewModel>(_articleManager.GetArticle(articleId));
            var response = Request.CreateResponse(HttpStatusCode.OK, article);
            return response;
        }

        [HttpGet, Route("get")]
        public HttpResponseMessage GetTopArticles()
        {
            var articles = Mapper.Map<IList<Article>, IList<ArticleViewModel>>(_articleManager.ListTopArticles());
            var response = Request.CreateResponse(HttpStatusCode.OK, articles);
            return response;
        }
        [HttpPut, Route("like/{articleId:int}")]
        public HttpResponseMessage Like(int userId, int articleId)
        {
            var user = new User { Id = userId };
            var article = new Article { Id = articleId };
            ArticlePublishResponse publishResponse = _articleManager.LikeArticle(user, article);
            var response = publishResponse.Success
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Failure");
            return response;
        }

        [HttpPost, Route("publish/{articleId:int}")]
        public HttpResponseMessage Publish(int userId, Models.Publish.ArticleViewModel articleViewModel)
        {
            var user = new User { Id = userId };
            var article = Mapper.Map<Article>(articleViewModel);
            ArticlePublishResponse publishResponse = _articleManager.Publish(user, article);
            var response = publishResponse.Success
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failure");
            return response;
        }
    }
}
