namespace ArtGallery.Web.ViewModels.BlogPosts
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class BlogCommentViewModel : IMapFrom<BlogPost>
    {
        public int CommentId { get; set; }

        public string BlogPostId { get; set; }

        public string BlogPost { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }
    }
}
