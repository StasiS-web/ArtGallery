namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.ArtStore;

    public class ArtStoreService : IArtStoreService
    {
        private IAppRepository storeRepo;

        public ArtStoreService(IAppRepository storeRepo)
        {
            this.storeRepo = storeRepo;
        }

        public IEnumerable<ArtStoreViewModel> GetAll()
        {
            return this.storeRepo
                .All<ArtStore>()
                .To<ArtStoreViewModel>()
                .ToList();
        }

        public IEnumerable<int> GetById<T>(int id)
        {
            var blogPost = this.storeRepo
                     .All<ArtStoreViewModel>()
                     .Where(x => x.ArtId == id)
                     .FirstOrDefault();

            return (IEnumerable<int>)blogPost;
        }
    }
}
