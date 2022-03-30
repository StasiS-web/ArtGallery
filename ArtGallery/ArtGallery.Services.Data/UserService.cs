namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.Users;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.MessageConstants;

    public class UserService : IUserService
    {
        private readonly IAppRepository userRepo;

        public UserService(IAppRepository userRepo)
        {
            this.userRepo = userRepo;
         }

        public IEnumerable<UserViewModel> GetAllUser(string userId)
        {
            return this.userRepo
                .All<UserViewModel>()
                .Where(u => u.UserId == userId)
                .ToList();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await this.userRepo.GetByIdAsync<ApplicationUser>(userId);
        }

        public string GetIdByUsername(UserViewModel model)
        {
            var user = this.userRepo
                .All<ArtGalleryUser>()
                .SingleOrDefault(x => x.UserName == model.UserName);

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(InvalidUsername, model.UserName));
            }

            return user.Id;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return this.userRepo.All<ArtGalleryUser>()
                                 .Select(u => new UserListViewModel()
                                 {
                                     Email = u.Email,
                                     UserName = u.UserName,
                                     Id = u.Id,
                                     Name = $"{u.FirstName} {u.LastName}",
                                 })
                                 .ToList();
        }

        public async Task<UserEditViewModel> GetUserToEdit(string userId)
        {
            var user = await this.userRepo.GetByIdAsync<ArtGalleryUser>(userId);

            return new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await this.userRepo
                .GetByIdAsync<ArtGalleryUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                this.userRepo.SaveChangesAsync();
                result = true;
            }

            return result; 
        }

        public async Task<string> DeleteAsync(string userId)
        {
            var currentUser = await this.userRepo
                .AllWithDeleted<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.UrlImage)
                .SingleOrDefaultAsync();

            var id = currentUser?.Id ?? string.Empty;

            if (id == " ")
            {
                id = string.Empty;
            }

            return id;
        }
    }
}
