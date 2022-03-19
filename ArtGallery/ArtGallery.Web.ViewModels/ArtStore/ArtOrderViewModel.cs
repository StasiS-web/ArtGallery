namespace ArtGallery.Web.ViewModels.ArtStore
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class ArtOrderViewModel : IMapFrom<ArtOrder>
    {
        public string OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
