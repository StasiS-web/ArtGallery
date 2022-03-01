namespace ArtGallery.Web.ViewModels.AdministrationInputModels
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ErrorMessages;
    using static ArtGallery.Common.GlobalConstants.Privacy;

    public class PrivacyCreateInputModel
    {
        [Display(Name = PageContentDisplayName)]
        [Required(ErrorMessage = EmptyField)]
        [StringLength(PageContentMaxLength, MinimumLength = PageContentMinLength, ErrorMessage = PageContentLength)]
        public string PageConetent { get; set; }
    }
}
