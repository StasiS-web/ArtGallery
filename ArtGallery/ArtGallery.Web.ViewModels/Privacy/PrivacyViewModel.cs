namespace ArtGallery.Web.ViewModels.Privacy
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Services.Mapping.Contracts;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.Privacy;
    using static ArtGallery.Common.MessageConstants;
    using Privacy = ArtGallery.Data.Models.Privacy;

    public class PrivacyVewModel : IMapTo<Privacy>, IMapFrom<Privacy>
    {
        public int Id { get; set; }

        public string PageContent { get; set; }
    }
}