using ArtGallery.Core.Contracts;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Infrastructure.Data.Models.Enumeration;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Test.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ArtGallery.Tests
{
    public class EventServiceTests
    {
        private InMemoryDbContext dbContext;
        private ServiceProvider serviceProvider;

        [Fact]
        public void DeleteEventShouldWork()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();
            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IAppRepository, AppRepository>()
                .AddScoped<IEventService, EventService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<EventService>();
            var eventToDelete = new Event()
            {
                Id = 2,
                Name = "Event",
                Date = DateTime.UtcNow,
                Type = EventType.InPerson,
                Description = "Content",
            };

            service.Delete(eventToDelete.Id);
            
        }

        private async Task SeedDbAsync(IAppRepository repo)
        {
            var events = new Event()
            {
                Id = 6,
                Name = "Art Fair",
                Price = 12,
                Date = DateTime.UtcNow,
                Type = EventType.InPerson,
                Description = "Discover an array of engaging installations, topical talks, hundreds of programmed events across amazing venues at Clerkenwell Design Week. This amazing independent design festival returns for its 11th edition. During this event, you'll have the chance to discover more than 200 exhibitors showcasing their captivating installations, talks and hundreds of programmed events. Whilst you're there feast upon the area’s delicious array of food and drink choices.",
            };

            await repo.AddAsync(events);
            await repo.SaveChangesAsync();
        }
    }
}
