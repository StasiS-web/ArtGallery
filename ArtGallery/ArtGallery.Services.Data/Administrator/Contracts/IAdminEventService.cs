namespace ArtGallery.Services.Data.Administrator.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.Events;

    public interface IAdminEventService
    {
        Task<bool> CreateEventAsync(EventCreateInputViewModel model);

        Task<bool> UpdateEventAsync(EventEditViewModel model);

        Task ConfirmAsync(int id);

        Task DeclineAsync(int id);

        void Delete(int id);
    }
}
