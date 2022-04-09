
namespace ArtGallery.Core.Contracts
{
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.ArtStore;

    public interface IArtStoreService
    {
        Task CreateArtAsync(ArtStoreCreateInputModel model);

        Task<bool> UpdateArtStore(ArtStoreViewModel model);

        Task DeleteAsync(int id);

        IEnumerable<int> GetById<T>(int id);

        IEnumerable<ArtStoreViewModel> GetAll();

        ArtDetailsViewModel Details(int artId);

        Task<bool> CheckIfArtExists(int artId);
    }
}
