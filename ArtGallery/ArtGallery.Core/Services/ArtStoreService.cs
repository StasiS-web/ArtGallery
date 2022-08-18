namespace ArtGallery.Core.Services
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.ArtStore;
    using ArtGallery.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class ArtStoreService : IArtStoreService
    {
        private IAppRepository _storeRepo;

        public ArtStoreService(IAppRepository storeRepo)
        {
            this._storeRepo = storeRepo;
        }

        public async Task CreateArtAsync(ArtStoreCreateInputModel model)
        {
            var art = new ArtStoreCreateInputModel
            {
                PaintingName = model.PaintingName,
                AuthorName = model.AuthorName,
                UrlImage = model.UrlImage,
                Price = model.Price,
                Description = model.Description,
            };

            this._storeRepo.AddAsync(art);
            await this._storeRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateArtStore(ArtStoreViewModel model)
        {
            bool result = false;
            var artStore = this._storeRepo
                .All<ArtStoreViewModel>()
                .SingleOrDefault(x => x.ArtId == model.ArtId);

            if (artStore != null)
            {
                artStore.ArtId = model.ArtId;
                artStore.PaintingName = model.PaintingName;
                artStore.Price = model.Price;
                artStore.Description = model.Description;

                await this._storeRepo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var art = this._storeRepo
                .All<ArtStoreViewModel>()
                .Where(x => x.ArtId == id)
                .FirstOrDefault();

            this._storeRepo.Delete(art);
            this._storeRepo.SaveChanges();
        }

        public IEnumerable<ArtStoreViewModel> GetAll()
        {
            return this._storeRepo
                .All<ArtStoreViewModel>()
                .To<ArtStoreViewModel>()
                .ToList();
        }

        public IEnumerable<int> GetById<T>(int id)
        {
            var blogPost = this._storeRepo
                     .All<ArtStoreViewModel>()
                     .Where(x => x.ArtId == id)
                     .FirstOrDefault();

            return (IEnumerable<int>)blogPost;
        }

        public ArtDetailsViewModel Details(int artId)
        {
            var store = this._storeRepo.AllReadonly<ArtStoreViewModel>()
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
            var even = await this._storeRepo
                        .All<ArtStoreViewModel>()
                        .FirstOrDefaultAsync(x => x.ArtId == artId);

            return even != null;
        }
    }
}
