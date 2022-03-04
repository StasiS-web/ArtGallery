namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogPostCreateInputModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [DataType(DataType.ImageUrl)]
        public string UrlImage { get; set; }

        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [MinLength(AdminAuthorMinLength)]
        [MaxLength(AdminAuthorMaxLength)]
        public string Author { get; set; }
    }
}
