namespace ArtGallery.Web.ViewModels.ArtStore
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class ArtStoreViewModel : IMapFrom<ArtStore>
    {
        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public string AuthorName { get; set; }

        public string UrlImage { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
