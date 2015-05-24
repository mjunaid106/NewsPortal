using Microsoft.Practices.Unity;
using System.Web.Http;
using NewsPortal.Data.Context;
using NewsPortal.Data.Interfaces;
using NewsPortal.Data.Repository;
using NewsPortal.Domain;
using NewsPortal.Domain.Authentication;
using NewsPortal.Domain.Interfaces;
using Unity.WebApi;

namespace NewsPortal.Web.Api
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();

            //container.RegisterType<IAuthentication, Authentication>();
            //container.RegisterType<IArticleManager, ArticleManager>();
            //container.RegisterType<IArticleRepository, ArticleRepository>();
            //container.RegisterType<INewsPortalContext, NewsPortalContext>();
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.None);
            config.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        }
    }
}