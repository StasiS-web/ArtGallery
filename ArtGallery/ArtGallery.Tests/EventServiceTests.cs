using ArtGallery.Core.Contracts;
using ArtGallery.Core.Models.Events;
using ArtGallery.Core.Models.Home;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Infrastructure.Data.Models.Enumeration;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Test.Common;
using ArtGallery.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ArtGallery.Tests
{
    public class EventServiceTests
    {
        private Mock<IAppRepository> _appRepository;
        private Mock<IEventService> _eventService;
        private ApplicationDbContext _context;

        public EventServiceTests()
        {
            _appRepository = new Mock<IAppRepository>();
            _eventService = new Mock<IEventService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "eventDb")
           .Options);
        }

        [Fact]
        public void DeleteEventShouldWork()
        {

            //Assert

            _eventService.Setup(x => x.Delete(It.IsAny<int>()));

            // Act
            var service = new EventService(_appRepository.Object, _context);
            var eventToDelete = ObjectGenerator.GetEventObject();
            service.Delete(2);

            // Verify
            _eventService.Verify(x => x.Delete(It.IsAny<int>()), Times.Never());
        }


        [Fact]
        public void AllEventsCount_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.All<Event>()).Returns(new List<Event>
            { new Event(),new Event() }.AsQueryable());

            _eventService.Setup(x => x.AllEventsCount()).Returns(2);

            // Act
            var service = new EventService(_appRepository.Object, _context);

            // Verify
            _eventService.Verify(x => x.AllEventsCount(), Times.Never());
            Assert.Equal(2, _eventService.Object.AllEventsCount());
        }

        [Fact]
        public void GetByIdAsync_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.GetByIdAsync<Event>(1)).Returns(Task.Run(() => ObjectGenerator.GetEventObject()));

            _eventService.Setup(x => x.GetByIdAsync(1)).Returns(new List<int>());

            // Act
            var service = new EventService(_appRepository.Object, _context);
            var result = service.GetByIdAsync(1);
            // Verify
            _eventService.Verify(x => x.GetByIdAsync(1), Times.Never());
            Assert.Equal(new List<int>(), _eventService.Object.GetByIdAsync(1));
        }


        [Fact]
        public async void GetUpcomingByIdAsync_ShouldWork()
        {

            //Assert
            _eventService.Setup(x => x.GetUpcomingByIdAsync<UpcomingEventViewModel>(1)).Returns(Task.Run(() => (new List<UpcomingEventViewModel>().AsQueryable()).AsEnumerable()));

            // Act
            var service = new EventService(_appRepository.Object, _context);
            var result = await service.GetUpcomingByIdAsync<UpcomingEventViewModel>(1);

            // Verify
            _eventService.Verify(x => x.GetUpcomingByIdAsync<UpcomingEventViewModel>(1), Times.Never());
            Assert.Equal(result, _eventService.Object.GetUpcomingByIdAsync<UpcomingEventViewModel>(1).Result);
        }

        [Fact]
        public async void AddAsync_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.AddAsync<Event>(ObjectGenerator.GetEventObject())).Returns(Task.Run(() => ObjectGenerator.GetEventObject()));

            _eventService.Setup(x => x.AddAsync(ObjectGenerator.GetEventCreateInputViewModelObject()));

            // Act
            var service = new EventService(_appRepository.Object, _context);

            await service.AddAsync(ObjectGenerator.GetEventCreateInputViewModelObject());

            // Verify
            _eventService.Verify(x => x.AddAsync(ObjectGenerator.GetEventCreateInputViewModelObject()), Times.Never());
        }

        [Fact]
        public async void UpdateEventAsync_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.Update<Event>(ObjectGenerator.GetEventObject()));

            _eventService.Setup(x => x.UpdateEventAsync(ObjectGenerator.GetEventEditViewModelObject()));

            // Act
            var service = new EventService(_appRepository.Object, _context);

            await service.UpdateEventAsync(ObjectGenerator.GetEventEditViewModelObject());

            // Verify
            _eventService.Verify(x => x.UpdateEventAsync(ObjectGenerator.GetEventEditViewModelObject()), Times.Never());
        }

        [Fact]
        public void GetEventDetailsByIdAsync_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.All<EventViewModel>()).Returns(new List<EventViewModel>().AsQueryable());

            _eventService.Setup(x => x.GetEventDetailsByIdAsync<EventViewModel>(1));

            // Verify
            _eventService.Verify(x => x.GetEventDetailsByIdAsync<EventViewModel>(1), Times.Never());
        }

        [Fact]
        public void CheckIfEventExists_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.All<EventViewModel>()).Returns(new List<EventViewModel>().AsQueryable());

            _eventService.Setup(x => x.CheckIfEventExists(1)).Returns(Task.Run(() => true));
            
            // Verify
            _eventService.Verify(x => x.GetEventDetailsByIdAsync<EventViewModel>(1), Times.Never());
        }

        [Fact]
        public void CheckAvailableEvents_ShouldWork()
        {

            //Assert
            _appRepository.Setup(x => x.All<EventViewModel>()).Returns(new List<EventViewModel>().AsQueryable());

            _eventService.Setup(x => x.CheckAvailableEvents(1,DateTime.Now)).Returns(Task.Run(() => true));

            // Verify
            _eventService.Verify(x => x.CheckAvailableEvents(1,DateTime.Now), Times.Never());
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
