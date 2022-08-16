using ArtGallery.Core.Contracts;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;
using ArtGallery.Tests.Common;
using ArtGallery.Core.Services;

namespace ArtGallery.Tests
{
    public class ArtOrderServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<IArtOrderService> _artOrderService;
        private ApplicationDbContext _context;
        public ArtOrderServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _artOrderService = new Mock<IArtOrderService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "artOrderDb")
         .Options);
        }

        [Fact]
        public void CreateOrder_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync(ObjectGenerator.GetArtOrderViewModelObject()));
            _artOrderService.Setup(x => x.CreateOrder(ObjectGenerator.GetArtOrderViewModelObject()));

            // Act
            var service = new ArtOrder(_repo.Object, _context);

            // Verify
            _artOrderService.Verify(x => x.CreateOrder(ObjectGenerator.GetArtOrderViewModelObject()), Times.Never);
        }


        [Fact]
        public void ReceivedOrder_Test()
        {
            // Assert
            _artOrderService.Setup(x => x.ReceivedOrder("1")).Returns(Task.Run(() => true));

            // Act
            var service = new ArtOrder(_repo.Object, _context);

            // Verify
            _artOrderService.Verify(x => x.ReceivedOrder("1"), Times.Never);
        }

        [Fact]
        public void CancleOrder_Test()
        {
            // Assert
            _artOrderService.Setup(x => x.CancleOrder("1")).Returns(Task.Run(() => true));

            // Act
            var service = new ArtOrder(_repo.Object, _context);

            // Verify
            _artOrderService.Verify(x => x.CancleOrder("1"), Times.Never);
        }
    }
}
