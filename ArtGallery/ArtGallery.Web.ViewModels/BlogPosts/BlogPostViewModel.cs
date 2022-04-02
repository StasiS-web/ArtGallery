namespace ArtGallery.Web.ViewModels.BlogPosts
{
    using System;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;

    public class BlogPostViewModel : IMapTo<BlogPost>, IMapFrom<BlogPost>
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public IFormFile UrlImage { get; set; }

        public string Content { get; set; }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public ReactionType UserReaction { get; set; }
    }
}
