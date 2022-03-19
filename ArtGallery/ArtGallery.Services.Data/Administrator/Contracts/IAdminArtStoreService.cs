namespace ArtGallery.Services.Data.Administrator.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.ArtStore;

    public interface IAdminArtStoreService
    {
        Task CreateArtAsync(ArtStoreCreateInputModel model);

        Task<bool> UpdateArtStore(ArtStoreViewModel model);

        void Delete(int id);
    }
}
