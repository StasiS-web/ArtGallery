namespace ArtGallery.Infrastructure.Seeding.Contracts
{
    using System;
    using System.Threading.Tasks;
    using ArtGallery.Infrastructure.Data;

    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
