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

    public class RoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, AdministratorRoleName);
            await SeedRoleAsync(roleManager, GalleryManagerRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
