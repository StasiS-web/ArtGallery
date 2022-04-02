namespace ArtGallery.Web.ViewModels.ArtStore
{
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;

    public class ArtOrderViewModel : IMapTo<ArtOrder>, IMapFrom<ArtOrder>
    {
        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
