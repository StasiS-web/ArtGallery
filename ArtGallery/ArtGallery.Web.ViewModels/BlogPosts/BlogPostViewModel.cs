namespace ArtGallery.Web.ViewModels.BlogPosts
{
    using System;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public int BlogPostId { get; set; }

        public string Title { get; set; }

        public string UrlImage { get; set; }

        public string Content { get; set; }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserReaction { get; set; }
    }
}
