namespace ArtGallery.Core.Services
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.ShoppingCart;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IAppRepository _cartRepo;

        public ShoppingCartService(IAppRepository cartRepo)
        {
            this._cartRepo = cartRepo;
        }

        public IEnumerable<ShoppingCartViewModel> AddArt(int artId, string userId, decimal price)
        {
            var user = this._cartRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            var artInCart = this._cartRepo.All<ArtStore>()
                .FirstOrDefault(u => u.Id == artId); ;

            user.ShoppingCart.Arts.Add(artInCart);

            try
            {
                _cartRepo.SaveChanges();
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
            var user = this._cartRepo.All<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.ShoppingCart)
                .ThenInclude(a => a.Arts)
                .FirstOrDefault();

            user.ShoppingCart.Arts.Clear();

            this._cartRepo.SaveChanges();
        }

        public async Task ClearCartAsync(string userId)
        {
            var arts = this._cartRepo
                   .All<ArtGalleryUser>()
                   .Where(u => u.Id == userId)
                   .ToList();

            foreach (var art in arts)
            {
                this._cartRepo.HardDelete(art);
            }

            await this._cartRepo.SaveChangesAsync();
        }

        public IEnumerable<ShoppingCartViewModel> GetArts(string userId)
        {
            var user = this._cartRepo.All<ArtGalleryUser>()
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
            var artInTheCart = this._cartRepo.All<ShoppingCartViewModel>()
                .SingleOrDefault(a => a.ShoppingCartId == artId);

            if (artInTheCart.Quantity <= 1)
            {
                isIncreased = false;
            }

            artInTheCart.Quantity--;
            int result = this._cartRepo.SaveChanges();

            if (result > 0)
            {
                isIncreased = true;
            }
        }
    }
}
