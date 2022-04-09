namespace ArtGallery.Infrastructure.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using ArtGallery.Common;
    using ArtGallery.Infrastructure.Data;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Seeding.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using static ArtGallery.Common.GlobalConstants;

    public class AccountsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            // Create Admin
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountSeeding.AdminEmail,
                AdministratorRoleName);

            // Create GallaryManager
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountSeeding.GalleryManagerEmail,
                GalleryManagerRoleName);

            // Create User
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountSeeding.UserEmail,
                UserRoleName);
        }

        private static async Task CreateUser(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string email, string roleName = null)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var password = GlobalConstants.AccountSeeding.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByIdAsync(roleName);

                if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
                {
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                     }
                }
            }
            else
            {
                if (!userManager.Users.Any(x => x.Roles.Count() == 0))
                {
                    var result = await userManager.CreateAsync(user, password);
                }
            }
        }
    }
}
