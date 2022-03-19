namespace ArtGallery.Services.Data.Administrator.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminEventService
    {
        Task CreateEventAsync(EventCreateInputViewModel model);

        Task ConfirmAsync(int id);

        void Delete(int id);
    }
}
