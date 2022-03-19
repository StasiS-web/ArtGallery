namespace ArtGallery.Services.Data.Administration.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminArtStoreService
    {
        Task CreateArtAsync(ArtStoreCreateInputModel model);

        void Delete(int id);
    }
}
