namespace ArtGallery.Web.ViewModels.About
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class FaqEntityDetailViewModel : IMapFrom<FaqEntity>
    {
        public int FaqId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
