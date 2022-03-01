namespace ArtGallery.Web.ViewModels.AdministrationInputModels
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.BlogPost;

    public class BlogCreateInputModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [DataType(DataType.ImageUrl)]
        public string UrlImage { get; set; }

        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        [StringLength(AdminAuthorMaxLength, MinimumLength = AdminAuthorMinLength)]
        public string Author { get; set; }
    }
}
