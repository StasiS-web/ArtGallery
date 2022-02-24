namespace ArtGallery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Common;
    using ArtGallery.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogComment : BaseDeletableModel<string>
    {
        [Required]
        public string BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        [MaxLength(CommentContentMaxLength), Required]
        public string CommentContent { get; set; }

        public string UserId { get; set; }

        [Required]
        public ArtGalleryUser User { get; set; }
    }
}
