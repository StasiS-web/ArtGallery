namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Web.ViewModels.Users;

    public interface IUserService
    {
        Task<string> GetUserAsync(string username);

        Task GetUserByRoleAsync(string Username);

        (string userId, bool isCorrect) IsLoginCorrectAsync(LoginInputViewModel model);

        string CalculateHashAsync(string password);

        string Login(LoginInputViewModel model);

        string GetCartByUserId(string userId);

        Task DeleteAsync(int userId);
    }
}
