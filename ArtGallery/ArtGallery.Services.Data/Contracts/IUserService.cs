namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Web.ViewModels.Users;

    public interface IUserService
    {
        string Login(LoginInputViewModel model);

        void Logout();

        (bool isRegister, string error) Register(RegisterInputViewModel model);

        IEnumerable<UserViewModel> GetAllUser(string userId);

        string GetUserById(UserViewModel model);

        string GetIdByUsername(UserViewModel model);

        Task<string> DeleteAsync(string userId);
    }
}
