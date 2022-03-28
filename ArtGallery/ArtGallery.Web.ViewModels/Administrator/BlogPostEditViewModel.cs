namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogPostEditViewModel
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }
    }
}
