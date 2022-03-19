namespace ArtGallery.Services.Data.Administration.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminEventService
    {
        Task CreateEventAsync(EventCreateInputViewModel model);

        Task ConfirmAsync(int id);

        void Delete(int id);
    }
}
