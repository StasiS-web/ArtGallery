using ArtGallery.Core.Contracts;
using ArtGallery.Core.Models.FaqEntity;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ArtGallery.Tests
{
    public class AboutServiceTests
    {
        private Mock<IAppRepository> _repo;
        private Mock<IAboutService> _abouteService;
        private ApplicationDbContext _context;

        public AboutServiceTests()
        {
            _abouteService = new Mock<IAboutService>();
            _repo = new Mock<IAppRepository>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "abouteDb")
          .Options);
        }

        [Fact]
        public void CreateAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync(ObjectGenerator.GetFaqCreateInputViewModelObject())).Returns(Task.Run(() => ObjectGenerator.GetFaqCreateInputViewModelObject()));
            _abouteService.Setup(x => x.CreateAsync(ObjectGenerator.GetFaqCreateInputViewModelObject())).Returns(Task.Run(() => ObjectGenerator.GetFaqViewModelObject()));

            // Act
            var service = new AboutService(_repo.Object, _context);

            // Verify
            _abouteService.Verify(x => x.CreateAsync(ObjectGenerator.GetFaqCreateInputViewModelObject()), Times.Never);
        }

        [Fact]
        public void EditAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.Update(ObjectGenerator.GetFaqEditViewModelObject()));
            _abouteService.Setup(x => x.EditAsync(ObjectGenerator.GetFaqEditViewModelObject())).Returns(Task.Run(() => ObjectGenerator.GetFaqViewModelObject()));

            // Act
            var service = new AboutService(_repo.Object, _context);

            // Verify
            _abouteService.Verify(x => x.EditAsync(ObjectGenerator.GetFaqEditViewModelObject()), Times.Never);
        }

        [Fact]
        public void DeleteById_Test()
        {
            // Assert
            _repo.Setup(x => x.Delete(ObjectGenerator.GetFaqEditViewModelObject()));
            _abouteService.Setup(x => x.DeleteById(1));

            // Act
            var service = new AboutService(_repo.Object, _context);

            // Verify
            _abouteService.Verify(x => x.DeleteById(1), Times.Never);
        }

        [Fact]
        public async void GetAllFaqsAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<FaqViewModel>());
            _abouteService.Setup(x => x.GetAllFaqsAsync<FaqViewModel>());

            // Act
            var service = new AboutService(_repo.Object, _context);
            await service.GetAllFaqsAsync<FaqViewModel>();

            // Verify
            _abouteService.Verify(x => x.GetAllFaqsAsync<FaqViewModel>(), Times.Never);
        }

        [Fact]
        public void GetByIdAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.GetByIdAsync<FaqViewModel>(1));
            _abouteService.Setup(x => x.GetByIdAsync<FaqViewModel>(1));

            // Act
            var service = new AboutService(_repo.Object, _context);

            // Verify
            _abouteService.Verify(x => x.GetByIdAsync<FaqViewModel>(1), Times.Never);
        }
    }
}
