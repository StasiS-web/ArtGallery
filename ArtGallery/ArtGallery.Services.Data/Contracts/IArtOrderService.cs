namespace ArtGallery.Services.Data.Contracts
{
    using ArtGallery.Web.ViewModels.ArtStore;

    public interface IArtOrderService
    {
        Task CreateOrder(ArtOrderViewModel model);

        Task<bool> ReceivedOrder(string artId);

        Task<bool> CancleOrder(string artId);
    }
}
