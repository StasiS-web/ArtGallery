namespace ArtGallery.Services.Data.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Administrator.Contracts;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.ArtStore;

    public class AdminArtStoreService : IAdminArtStoreService
    {
        private readonly IAppRepository artRepo;

        public AdminArtStoreService(IAppRepository artRepo)
        {
            this.artRepo = artRepo;
        }

        public async Task CreateArtAsync(ArtStoreCreateInputModel model)
        {
            await this.artRepo.AddAsync(new ArtStoreViewModel
            {
                PaintingName = model.PaintingName,
                AuthorName = model.AuthorName,
                UrlImage = model.UrlImage,
                Price = model.Price,
                Description = model.Description,
            });

            await this.artRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateArtStore(ArtStoreViewModel model)
        {
            bool result = false;
            var artStore = this.artRepo
                .All<ArtStore>()
                .SingleOrDefault(x => x.Id == model.ArtId);

            if (artStore != null)
            {
                artStore.Id = model.ArtId;
                artStore.PaintingName = model.PaintingName;
                artStore.Price = model.Price;
                artStore.Description = model.Description;

                this.artRepo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public void Delete(int id)
        {
            var art = this.artRepo
                .All<ArtStoreViewModel>()
                .Where(x => x.ArtId == id)
                .FirstOrDefault();

            this.artRepo.Delete(art);
            this.artRepo.SaveChanges();
        }
    }
}
