namespace ArtGallery.Web.ViewModels.ArtStore
{
    using ArtGallery.Services.Mapping.Contracts;
    using Microsoft.AspNetCore.Http;

    public class ArtDetailsViewModel : IMapFrom<ArtStoreViewModel>
    {
        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public string AuthorName { get; set; }

        public IFormFile UrlImage { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }
    }
}
