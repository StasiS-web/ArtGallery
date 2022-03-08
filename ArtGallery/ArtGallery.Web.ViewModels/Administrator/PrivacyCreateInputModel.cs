namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.Privacy;
    using static ArtGallery.Common.MessageConstants.ErrorMessages;

    public class PrivacyCreateInputModel
    {
        [Display(Name = PageContentDisplayName)]
        [Required(ErrorMessage = EmptyField)]
        [MinLength(PageContentMinLength)]
        [MaxLength(PageContentMaxLength, ErrorMessage = PageContentLength)]
        public string PageConetent { get; set; }
    }
}
