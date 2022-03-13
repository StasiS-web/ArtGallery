namespace ArtGallery.Services.Data.Contracts
{
    using ArtGallery.Web.ViewModels.ArtStore;

    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartViewModel> AddArt(int artId, string userId, decimal price);

        void BuyArts(string userId);

        IEnumerable<ShoppingCartViewModel> GetArts(string userId);

        void IncreaseQuatity(string artId, bool isIncreased);

        Task ClearCartAsync(string userId);
    }
}
