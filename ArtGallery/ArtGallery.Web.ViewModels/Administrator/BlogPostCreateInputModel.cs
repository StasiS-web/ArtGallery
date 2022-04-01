namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;
    using ArtGallery.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.BlogPost;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.MessageConstants;

    public class BlogPostCreateInputModel : IMapTo<BlogPostViewModel>, IMapFrom<BlogPostViewModel>
    {

        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string UrlImage { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [DataType(DataType.Upload)]
        [Display(Name = CoverImageDisplayName)]
        public IFormFile CoverImage { get; set; }

        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }

        [Required]
        [MaxLength(AdminAuthorMaxLength)]
        [MinLength(AdminAuthorMinLength)]
        public string Author { get; set; }

        public string UserReaction { get; set; }
    }
}
