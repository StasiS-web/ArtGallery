namespace ArtGallery.Core.Contracts
{ 
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Users;
    using ArtGallery.Infrastructure.Data.Models;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUser(string userId);

        Task<ApplicationUser> GetUserById(string userId);

        Task<UserEditViewModel> GetUserToEdit(string userId);

        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<bool> UpdateUser(UserEditViewModel model);

        string GetIdByUsername(UserViewModel model);

        Task<string> DeleteAsync(string userId);
    }
}
