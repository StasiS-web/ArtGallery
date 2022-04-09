namespace ArtGallery.Core.Models.BlogPosts
{
    using System;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;

    public class BlogPostViewModel 
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
