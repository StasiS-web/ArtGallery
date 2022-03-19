namespace ArtGallery.Services.Data.Contracts
{
    using ArtGallery.Web.ViewModels.Events;

    public interface IEventOrderService
    {
        Task CreateOrder(EventOrderViewModel model);
    }
}
