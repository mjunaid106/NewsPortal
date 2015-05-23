using System;
using AutoMapper;
using NewsPortal.Data.Entities;
using NewsPortal.Web.Models;
using NewsPortal.Web.Models.ArticleViewModels;

namespace NewsPortal.Web
{
    public class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.CreateMap<Article, ListArticlesViewModel>()
                .ForMember(x => x.Author, auth => auth.MapFrom(src => src.Author.Name))
                .ForMember(x => x.Body, auth => auth.MapFrom(src => src.Body.Substring(0, Math.Min(src.Body.Length, 100))));
            
            Mapper.CreateMap<Article, ArticleDetailViewModel>().ReverseMap();
            Mapper.CreateMap<User, PublisherViewModel>().ReverseMap();
            Mapper.CreateMap<Author, AuthorViewModel>().ReverseMap();


        }
    }
}