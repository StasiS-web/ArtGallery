namespace ArtGallery.Web.ViewModels.Search
{
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class BlogPostDetailsLookupModel : IHaveCustomMappings
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public string UrlImage { get; set; }

        public IFormFile CoverImage { get; set; }

        public string Content { get; set; }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public string CreatedOn { get; set; }

        public ReactionType UserReaction { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPost, BlogPostDetailsLookupModel>()
                 .ForMember(b => b.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.ToString(NormalDateFormat)))
                 .ForMember(b => b.UrlImage, opt => opt.MapFrom(src => src.UrlImage));
        }
    }
}
