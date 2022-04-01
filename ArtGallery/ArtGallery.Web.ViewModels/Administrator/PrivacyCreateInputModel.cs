namespace ArtGallery.Web.ViewModels.Administrator
{
    using ArtGallery.Services.Mapping.Contracts;
    using ArtGallery.Web.ViewModels.Privacy;
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.Privacy;
    using static ArtGallery.Common.MessageConstants;

    public class PrivacyCreateInputModel : IMapTo<PrivacyVewModel>, IMapFrom<PrivacyVewModel>
    {
        [Display(Name = PageContentDisplayName)]
        [Required(ErrorMessage = EmptyField)]
        [MinLength(PageContentMinLength)]
        [MaxLength(PageContentMaxLength, ErrorMessage = PageContentLength)]

        public string PageConetent { get; set; }
    }
}
