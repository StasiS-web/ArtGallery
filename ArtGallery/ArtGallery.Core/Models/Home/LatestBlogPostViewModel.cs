namespace ArtGallery.Core.Models.Home
{
    using Microsoft.AspNetCore.Http;
    
    public class LatestBlogPostViewModel
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

    }
}
