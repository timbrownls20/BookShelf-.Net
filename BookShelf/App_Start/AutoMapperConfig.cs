using BookShelf.Models;
using BookShelf.WebServices.Google.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google = BookShelf.WebServices.Google.Messages;

namespace BookShelf
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Google.Book, Models.Book>()
                .ForMember(dest => dest.BookID, opts => opts.Ignore())
                .ForMember(dest => dest.BookIDSource, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.ISBN_10, opts => opts.MapFrom(src => GetISBN(src, "ISBN_10")))
                .ForMember(dest => dest.ISBN_13, opts => opts.MapFrom(src => GetISBN(src, "ISBN_13")))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.VolumeInfo.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.VolumeInfo.Description))
                .ForMember(dest => dest.PageCount, opts => opts.MapFrom(src => src.VolumeInfo.PageCount))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.VolumeInfo.Rating))
                .ForMember(dest => dest.SmallThumbnail, opts => opts.MapFrom(src => src.VolumeInfo.ImageLinks.SmallThumbnail))
                .ForMember(dest => dest.Thumbnail, opts => opts.MapFrom(src => src.VolumeInfo.ImageLinks.Thumbnail))
                .ForMember(dest => dest.Authors, opts => opts.MapFrom(src => src.VolumeInfo.Authors))
                ;

            AutoMapper.Mapper.CreateMap<string, Models.Author>()
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src))
                ;

        }

        private static string GetISBN(Google.Book src, string type)
        {
            var identifier = src?.VolumeInfo?.IndustryIdentifiers?.Where(x => x.Type == type).SingleOrDefault();
            return identifier != null ? identifier.Identifier : string.Empty;
        }
    }
}