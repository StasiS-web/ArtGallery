namespace ArtGallery.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogPost : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        // Blog Post are only created in the Administration Dashboard
        // so the Author is an Administrator
        [Required]
        [MaxLength(AdminAuthorMaxLength)]
        public string Author { get; set; }

        public ReactionType UserReaction { get; set; }
    }
}
