using BookShelf.Models;
using BookShelf.WebServices.Google.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<GoogleBook, Book>()
                .ForMember(dest => dest.BookID, opts => opts.Ignore())
                .ForMember(dest => dest.ISBN, opts => opts.Ignore())
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.VolumeInfo.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.VolumeInfo.Description));
        }
    }
}