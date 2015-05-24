using AutoMapper;
using NewsPortal.Data.Entities;

namespace NewsPortal.Web.Api
{
    public class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.CreateMap<Article, Models.Get.ArticleViewModel>().ReverseMap();
            Mapper.CreateMap<User, Models.Get.UserViewModel>().ReverseMap();
            Mapper.CreateMap<Author, Models.Get.AuthorViewModel>().ReverseMap();

            Mapper.CreateMap<Article, Models.Publish.ArticleViewModel>().ReverseMap();
            Mapper.CreateMap<User, Models.Publish.UserViewModel>().ReverseMap();
            Mapper.CreateMap<Author, Models.Publish.AuthorViewModel>().ReverseMap();
        }
    }
}