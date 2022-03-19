namespace ArtGallery.Services.Data.Administrator.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminArtStoreService
    {
        Task CreateArtAsync(ArtStoreCreateInputModel model);

        void Delete(int id);
    }
}
