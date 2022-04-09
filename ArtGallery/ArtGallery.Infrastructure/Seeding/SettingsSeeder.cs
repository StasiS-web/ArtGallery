namespace ArtGallery.Infrastructure.Seeding
{
    using ArtGallery.Infrastructure.Data;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Seeding.Contracts;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class SettingsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Settings.Any())
            {
                return;
            }

            await dbContext.Settings.AddAsync(new Setting { Name = "Setting1", Value = "value1" });
        }
    }
}
