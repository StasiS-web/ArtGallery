namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Common.Enums;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using static ArtGallery.Common.GlobalConstants;
    using static ArtGallery.Common.GlobalConstants.AccountSeeding;
    using ArtGalleryUser = ArtGallery.Data.Models.ArtGalleryUser;

    public class AccountService : IAccountService
    {
        private readonly IAppRepository repo;
        private readonly UserManager<ArtGalleryAccount> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(IAppRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateUser(string username, string password, string fullName, string email, string urlImage)
        {
            var user = new ArtGalleryUser
            {
                UserName = username,
                FullName = fullName,
                Email = email,
                UrlImage = urlImage,
            };

            var account = new ArtGalleryAccount
            {
                UserName = username,
                Email = email,
                UserId = user.Id,
                User = user,
            };

            var result = await userManager.CreateAsync(account, password);

            if (result.Succeeded)
            {
                await CreateRole(UserRoleName, account);

                user.Id = account.UserId;
                user = account.User;

                await repo.SaveChangesAsync();
            }
        }

        public async Task CreateRole(string roleName, ArtGalleryAccount user)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                var createRole = await roleManager.CreateAsync(role);

                if (createRole.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                    return;
                }
            }

            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task SeedRoleAsync()
        {
            var roles = Enum.GetValues(typeof(UserRoles));

            foreach (var role in roles)
            {
                var roleName = role.ToString();

                var isRoleExist = await this.roleManager.RoleExistsAsync(roleName);

                if (!isRoleExist)
                {
                    await this.roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
