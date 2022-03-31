namespace ArtGallery.Web.ViewModels.Administrator
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.BlogPost;
    using static ArtGallery.Common.MessageConstants;

    public class BlogPostEditViewModel
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required(ErrorMessage = EmptyField)]
        public IFormFile CoverImage { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }
    }
}
