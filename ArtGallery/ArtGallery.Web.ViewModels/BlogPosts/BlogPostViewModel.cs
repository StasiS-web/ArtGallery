namespace ArtGallery.Web.ViewModels.BlogPosts
{
    using System;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using Microsoft.AspNetCore.Http;

    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IFormFile UrlImage { get; set; }

        public string Content { get; set; }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public ReactionType UserReaction { get; set; }
    }
}
