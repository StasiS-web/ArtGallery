namespace ArtGallery.Services.Data.Contracts
{
    using ArtGallery.Web.ViewModels.ArtStore;

    public interface IArtOrderService
    {
        Task CreateOrder(ArtOrderViewModel model);
    }
}
