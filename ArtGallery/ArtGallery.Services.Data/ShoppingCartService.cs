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
        private readonly IAppRepository cartRepo;

        public ShoppingCartService(IAppRepository cartyRepo)
        {
            this.cartRepo = cartRepo;
        }

        public IEnumerable<ShoppingCartViewModel> AddArt(int artId, string userId, decimal price)
        {
            var user = this.cartRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            var artInCart = this.cartRepo.All<ArtStore>()
                .FirstOrDefault(u => u.Id == artId); ;

            user.ShoppingCart.Arts.Add(artInCart);

            try
            {
                cartRepo.SaveChanges();
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
            var user = this.cartRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            user.ShoppingCart.Arts.Clear();

            this.cartRepo.SaveChanges();
        }

        public async Task ClearCartAsync(string userId)
        {
            var arts = this.cartRepo
                   .All<ArtGalleryUser>()
                   .Where(u => u.Id == userId)
                   .ToList();

            foreach (var art in arts)
            {
                this.cartRepo.HardDelete(art);
            }

            await this.cartRepo.SaveChangesAsync();
        }

        public IEnumerable<ShoppingCartViewModel> GetArts(string userId)
        {
            var user = this.cartRepo.All<ArtGalleryUser>()
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
            var artInTheCart = this.cartRepo.All<ShoppingCartViewModel>()
                .SingleOrDefault(a => a.ShoppingCartId == artId);

            if (artInTheCart.Quantity <= 1)
            {
                isIncreased = false;
            }

            artInTheCart.Quantity--;
            int result = this.cartRepo.SaveChanges();

            if (result > 0)
            {
                isIncreased = true;
            }
        }
    }
}
