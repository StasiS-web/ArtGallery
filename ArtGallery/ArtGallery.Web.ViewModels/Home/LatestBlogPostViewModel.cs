namespace ArtGallery.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class LatestBlogPostViewModel : IMapFrom<BlogPost>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public IFormFile UrlImage { get; set; }

        public string Content { get; set; }

        public string ShortContect
        {
            get
            {
                var shortContent = this.Content;
                return shortContent.Length > 50
                    ? shortContent.Substring(0, 50) + "..."
                    : shortContent;
            }
        }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPost, LatestBlogPostViewModel>()
                .ForMember(b => b.UrlImage, opt => { opt.MapFrom(b => b.UrlImage); })
                .ForMember(b => b.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.ToString(NormalDateFormat)));
        }
    }
}
