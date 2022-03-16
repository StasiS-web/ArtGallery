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

        public string GetUserById(UserViewModel model)
        {
            var user = this.userRepo
                .All<ArtGalleryUser>()
                .SingleOrDefault(x => x.Id == model.UserId);

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(InvalidUserId, model.UserId));
            }

            return user.Id;
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
