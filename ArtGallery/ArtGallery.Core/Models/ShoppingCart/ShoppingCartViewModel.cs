namespace ArtGallery.Core.Models.ShoppingCart
{ 

    public class ShoppingCartViewModel
    {
        public string ShoppingCartId { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public decimal ArtPrice { get; set; }

        public int Quantity { get; set; }
    }
}
