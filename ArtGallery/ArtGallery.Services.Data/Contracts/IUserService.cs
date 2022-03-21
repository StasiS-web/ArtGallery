namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Web.ViewModels.Users;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUser(string userId);

        Task<ArtGalleryUser> GetUserById(string userId);

        Task<UserEditViewModel> GetUserToEdit(string userId);

        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<bool> UpdateUser(UserEditViewModel model);

        string GetIdByUsername(UserViewModel model);

        Task<string> DeleteAsync(string userId);
    }
}
