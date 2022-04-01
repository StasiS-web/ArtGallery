namespace ArtGallery.Web.ViewModels.BlogPosts
{
    using ArtGallery.Services.Mapping.Contracts;

    public class BlogCommentInputViewModel : IMapTo<BlogCommentViewModel>, IMapFrom<BlogCommentViewModel>
    {
        public int BlogPostId { get; set; }

        public string BlogPost { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }
    }
}
