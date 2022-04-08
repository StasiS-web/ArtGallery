namespace ArtGallery.Services.Data.Contracts
{
    using ArtGallery.Web.ViewModels.Events;

    public interface IEventOrderService
    {
        Task CreateOrder(EventOrderViewModel model, bool approved);

        Task ConfirmAsync(int id);

        Task DeclineAsync(int id);

    }
}
