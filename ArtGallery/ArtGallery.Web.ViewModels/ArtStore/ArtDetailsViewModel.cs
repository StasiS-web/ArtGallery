using Microsoft.AspNetCore.Http;

namespace ArtGallery.Web.ViewModels.ArtStore
{
    public class ArtDetailsViewModel
    {
        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public string AuthorName { get; set; }

        public IFormFile UrlImage { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }
    }
}
