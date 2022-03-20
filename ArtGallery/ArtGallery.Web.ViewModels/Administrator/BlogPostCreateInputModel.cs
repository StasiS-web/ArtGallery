namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogPostCreateInputModel
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [DataType(DataType.ImageUrl)]
        public IFormFile UrlImage { get; set; }

        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }

        [Required]
        [MaxLength(AdminAuthorMaxLength)]
        [MinLength(AdminAuthorMinLength)]
        public string Author { get; set; }
    }
}
