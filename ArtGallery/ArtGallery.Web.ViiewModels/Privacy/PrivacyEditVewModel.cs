namespace ArtGallery.Web.ViewModels.Privacy
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Services.Mapping;
    using static ArtGallery.Common.GlobalConstants.Privacy;
    using Privacy = ArtGallery.Data.Models.Privacy;

    public class PrivacyEditVewModel : IMapFrom<Privacy>
    {
        public int Id { get; set; }

        [Display(Name = PageContentDisplayName)]
        [MaxLength(PageContentMaxLength)]
        public string PageContent { get; set; }
    }
}
