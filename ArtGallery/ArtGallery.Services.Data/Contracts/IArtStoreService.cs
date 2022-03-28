namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.ArtStore;

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
