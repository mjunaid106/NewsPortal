using System.Web.Http;

namespace NewsPortal.Web.Api
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            // Web API configuration and services
            var config = new HttpConfiguration();
            // Web API routes
            UnityConfig.RegisterComponents(config);
            config.MapHttpAttributeRoutes();
            return config;
        }
    }
}
