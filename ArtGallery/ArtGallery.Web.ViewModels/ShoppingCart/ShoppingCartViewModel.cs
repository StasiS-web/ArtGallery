namespace ArtGallery.Web.ViewModels.ShoppingCart
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public string ShoppingCartId { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int Id { get; set; }

        public string PaintingName { get; set; }

        public decimal ArtPrice { get; set; }

        public int Quantity { get; set; }
    }
}
