namespace ArtGallery.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogComment : BaseDeletableModel<int>
    {
        [Required]
        public int BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        [Required]
        [MaxLength(CommentContentMaxLength)]
        public string CommentContent { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }
    }
}
