namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Web.ViewModels.Users;

    public interface IAccountService
    {
        Task CreateUser(string username, string password, string fullName, string email, string urlImage);

        Task CreateRole(string roleName, ArtGalleryAccount user);

        Task SeedRoleAsync();
    }
}
