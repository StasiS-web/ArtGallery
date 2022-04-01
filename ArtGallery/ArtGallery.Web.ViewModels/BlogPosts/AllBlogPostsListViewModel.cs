namespace ArtGallery.Web.ViewModels.BlogPosts
{
    public class AllBlogPostsListViewModel
    {
        public IEnumerable<BlogPostViewModel> AllBlogPosts { get; set; }

        public int BlogId { get; set; }

        public string Title { get; set; }

        public string UrlImage { get; set; }

        public string Content { get; set; }

        public string ShortContect
        {
            get
            {
                var shortContent = this.Content;
                return shortContent.Length > 100
                    ? shortContent.Substring(0, 100) + "..."
                    : shortContent;
            }
        }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Date => this.CreatedOn.ToShortDateString();

        public string UserReaction { get; set; }
    }
}
