namespace ArtGallery.Tests
{
    using ArtGallery.Core.Services;
    using ArtGallery.Infrastructure.Data;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;
    using ArtGallery.Test.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class SettingsServiceTests
    {

        [Fact]
        public void GetCountShouldReturn()
        {
            var repo = new Mock<IAppRepository>();
            repo.Setup(r => r.All<Setting>()).Returns(new List<Setting>
            {
                new Setting(),
                new Setting(),
                new Setting(),
            }.AsQueryable());

            var service = new SettingsService(repo.Object);
            Assert.Equal(3, service.GetCount());
            repo.Verify(x => x.All<Setting>(), Times.Once);
        }

        [Fact]
        public async Task GetCountShouldReturnUsingDbContext() // Failed
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            using var context = new ApplicationDbContext(options);
            context.Settings.Add(new Setting());
            context.Settings.Add(new Setting());
            context.Settings.Add(new Setting());
            await context.SaveChangesAsync();

            var repo = new AppRepository(context);
            var service = new SettingsService(repo);
            Assert.Equal(3, service.GetCount());
        }
    }
}
