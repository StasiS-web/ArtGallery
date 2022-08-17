namespace ArtGallery.Core.Contracts
{
    using ArtGallery.Core.Models.Events;
    using System.Threading.Tasks;

    public interface IEventOrderService
    {
        Task CreateOrder(EventOrderViewModel model, bool approved);

        Task ConfirmAsync(int id);

        Task DeclineAsync(int id);
    }
}
