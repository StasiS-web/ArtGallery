namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Web.ViewModels.ArtStore;
    using Microsoft.EntityFrameworkCore;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IAppRepository entityRepo;

        public ShoppingCartService(IAppRepository entityRepo)
        {
            this.entityRepo = entityRepo;
        }

        public IEnumerable<ShoppingCartViewModel> AddArt(int artId, string userId, decimal price)
        {
            var user = this.entityRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            var artInCart = this.entityRepo.All<ArtStore>()
                .FirstOrDefault(u => u.Id == artId); ;

            user.ShoppingCart.Arts.Add(artInCart);

            try
            {
                entityRepo.SaveChanges();
            }
            catch (Exception)
            { }

            return user.ShoppingCart.Arts
                .Select(a => new ShoppingCartViewModel()
                {
                    PaintingName = a.PaintingName,
                    ArtPrice = a.Price,
                });
        }

        public void BuyArts(string userId)
        {
            var user = this.entityRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            user.ShoppingCart.Arts.Clear();

            this.entityRepo.SaveChanges();
        }

        public async Task ClearCartAsync(string userId)
        {
            var arts = this.entityRepo
                   .All<ArtGalleryUser>()
                   .Where(u => u.Id == userId)
                   .ToList();

            foreach (var art in arts)
            {
                this.entityRepo.HardDelete(art);
            }

            await this.entityRepo.SaveChangesAsync();
        }

        public IEnumerable<ShoppingCartViewModel> GetArts(string userId)
        {
            var user = this.entityRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            return user.ShoppingCart.Arts
                .Select(a => new ShoppingCartViewModel()
                {
                    PaintingName = a.PaintingName,
                    ArtPrice = a.Price,
                });
        }

        public void IncreaseQuatity(string artId, bool isIncreased)
        {
            var artInTheCart = this.entityRepo.All<ShoppingCartViewModel>()
                .SingleOrDefault(a => a.ShoppingCartId == artId);

            if (artInTheCart.Quantity <= 1)
            {
                isIncreased = false;
            }

            artInTheCart.Quantity--;
            int result = this.entityRepo.SaveChanges();

            if (result > 0)
            {
                isIncreased = true;
            }
        }
    }
}
