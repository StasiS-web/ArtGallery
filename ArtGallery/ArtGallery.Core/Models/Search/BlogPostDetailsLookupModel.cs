namespace ArtGallery.Core.Models.Search
{
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;

    public class BlogPostDetailsLookupModel 
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

    }
}
