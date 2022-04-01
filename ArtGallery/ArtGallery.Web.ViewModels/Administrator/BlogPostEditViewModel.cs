namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Services.Mapping.Contracts;
    using ArtGallery.Web.ViewModels.BlogPosts;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.BlogPost;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.MessageConstants;

    public class BlogPostEditViewModel : IMapTo<BlogPostViewModel>, IMapFrom<BlogPostViewModel>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [Display(Name = CoverImageDisplayName)]
        public IFormFile UrlImage { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPostViewModel, BlogPostEditViewModel>()
                .ForMember(des => des.UrlImage, opt => opt.Ignore());
        }
    }
}
