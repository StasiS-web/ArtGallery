namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Web.ViewModels.ArtStore;

    public interface IArtStoreService
    {
        IEnumerable<int> GetById<T>(int id);

        IEnumerable<ArtStoreViewModel> GetAll();
    }
}
