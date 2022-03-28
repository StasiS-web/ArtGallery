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
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.ArtStore;
    using Microsoft.EntityFrameworkCore;

    public class ArtStoreService : IArtStoreService
    {
        private IAppRepository storeRepo;

        public ArtStoreService(IAppRepository storeRepo)
        {
            this.storeRepo = storeRepo;
        }


        public async Task CreateArtAsync(ArtStoreCreateInputModel model)
        {
            var art = new ArtStoreViewModel
            {
                PaintingName = model.PaintingName,
                AuthorName = model.AuthorName,
                UrlImage = model.UrlImage,
                Price = model.Price,
                Description = model.Description,
            };

            await this.storeRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateArtStore(ArtStoreViewModel model)
        {
            bool result = false;
            var artStore = this.storeRepo
                .All<ArtStore>()
                .SingleOrDefault(x => x.Id == model.ArtId);

            if (artStore != null)
            {
                artStore.Id = model.ArtId;
                artStore.PaintingName = model.PaintingName;
                artStore.Price = model.Price;
                artStore.Description = model.Description;

                await this.storeRepo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var art = this.storeRepo
                .All<ArtStoreViewModel>()
                .Where(x => x.ArtId == id)
                .FirstOrDefault();

            this.storeRepo.Delete(art);
            this.storeRepo.SaveChanges();
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

        public ArtDetailsViewModel Details(int artId)
        {
            var store = this.storeRepo.AllReadonly<ArtStoreViewModel>()
                              .Where(s => s.ArtId == artId)
                              .Select(s => new ArtDetailsViewModel
                              {
                                  ArtId = s.ArtId,
                                  PaintingName = s.PaintingName,
                                  Price = s.Price,
                                  UrlImage = s.UrlImage,
                                  AuthorName = s.AuthorName,
                                  Description = s.Description,
                              })
                              .FirstOrDefault();

            return store;
        }

        public async Task<bool> CheckIfArtExists(int artId)
        {
            var even = await this.storeRepo
                        .All<ArtStoreViewModel>()
                        .FirstOrDefaultAsync(x => x.ArtId == artId);

            return even != null;
        }
    }
}
