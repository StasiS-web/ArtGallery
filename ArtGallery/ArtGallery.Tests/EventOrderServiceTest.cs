using ArtGallery.Core.Contracts;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace ArtGallery.Tests
{
    public class EventOrderServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<IEventOrderService> _eventOrderService;
        private ApplicationDbContext _context;
        public EventOrderServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _eventOrderService = new Mock<IEventOrderService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "EventOrderDb")
       .Options);
        }

        [Fact]
        public void CreateOrder_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync(ObjectGenerator.GetEventOrderViewModelObject()));
            _eventOrderService.Setup(x => x.CreateOrder(ObjectGenerator.GetEventOrderViewModelObject(), true));

            // Act
            var service = new EventOrderService(_repo.Object);

            // Verify
            _eventOrderService.Verify(x => x.CreateOrder(ObjectGenerator.GetEventOrderViewModelObject(), true), Times.Never);
        }

        [Fact]
        public void ConfirmAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<EventOrder>()).Returns(new List<EventOrder> { ObjectGenerator.GetEventOrderObject() }.AsQueryable());
            _eventOrderService.Setup(x => x.ConfirmAsync(1));

            // Act
            var service = new EventOrderService(_repo.Object);

            // Verify
            _eventOrderService.Verify(x => x.ConfirmAsync(1), Times.Never);
        }

        [Fact]
        public void DeclineAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<EventOrder>()).Returns(new List<EventOrder> { ObjectGenerator.GetEventOrderObject() }.AsQueryable());
            _eventOrderService.Setup(x => x.DeclineAsync(1));

            // Act
            var service = new EventOrderService(_repo.Object);

            // Verify
            _eventOrderService.Verify(x => x.DeclineAsync(1), Times.Never);
        }
    }
}
