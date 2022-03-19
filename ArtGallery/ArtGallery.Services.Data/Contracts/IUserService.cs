namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Web.ViewModels.Users;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUser(string userId);

        string GetUserById(UserViewModel model);

        Task<bool> UpdateUser(UserEditModel model);

        string GetIdByUsername(UserViewModel model);

        Task<string> DeleteAsync(string userId);
    }
}
