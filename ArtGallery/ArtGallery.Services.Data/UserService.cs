namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Common.Repositories;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Web.ViewModels.Users;
    using static ArtGallery.Common.GlobalConstants.ErrorMessages;

    public class UserService : IUserService
    {
        private IDeletableEntityRepository<ArtGalleryUser> entityRepo;
        private IDeletableEntityRepository<ShoppingCart> carts;

        public UserService(IDeletableEntityRepository<ArtGalleryUser> entityRepository,
            IDeletableEntityRepository<ShoppingCart> shoppingCart)
        {
           this.entityRepo = entityRepository;
           this.carts = shoppingCart;
        }

        public async Task<string> GetUserAsync(string userId)
        {
            // var user = await this.entityRepo
            //    .AllAsNoTracking()
             //   .SingleOrDefault(u => u.Id == userId)
             //   (u => u.Id == userId);

           // if (user == null)
           // {
           //     throw new ArgumentNullException(string.Format(InvalidUserId, userId));
           // }

           // return user.Id;

            throw new NotImplementedException();
        }

        public Task GetUserByRoleAsync(string Username)
        {
            throw new NotImplementedException();
        }

        public (string userId, bool isCorrect) IsLoginCorrectAsync(LoginInputViewModel model)
        {
            /*bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByRoleAsync(model.Username);

            if (user != null)
            {
                isCorrect = user.PasswordHash == CalculateHashAsync(model.Password);
            }

            if (isCorrect)
            {
               // userId = user.Id;
            }

            return (userId, isCorrect);*/
            throw new NotImplementedException();
        }

        public string Login(LoginInputViewModel model)
        {
            var user = entityRepo.All<ArtGalleryUser>()
                 .Where(u => u.UserName == model.Username)
                 .Where(u => u.PasswordHash == this.CalculateHashAsync(model.Password))
                 .SingleOrDefault();

            return user?.Id;
        }

        public string CalculateHashAsync(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        public string GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
