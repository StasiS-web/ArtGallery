using ArtGallery.Core.Contracts;
using ArtGallery.Core.Models.ShoppingCart;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ArtGallery.Infrastructure.Data.Models;

namespace ArtGallery.Tests
{
    public class ShoppingCartServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<IShoppingCartService> _shoppingCartService;
        private ApplicationDbContext _context;
        public ShoppingCartServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _shoppingCartService = new Mock<IShoppingCartService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "ShoppingCartDb")
        .Options);
        }

        [Fact]
        public void AddArt_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ArtGalleryUser>()).Returns(new List<ArtGalleryUser> { ObjectGenerator.GetArtGalleryUserObject() }.AsQueryable());
            _shoppingCartService.Setup(x => x.AddArt(1, "1", 12));

            // Act
            var service = new ShoppingCartService(_repo.Object);

            // Verify
            _shoppingCartService.Verify(x => x.AddArt(1, "1", 12), Times.Never);
        }

        [Fact]
        public void BuyArts_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ArtGalleryUser>()).Returns(new List<ArtGalleryUser> { ObjectGenerator.GetArtGalleryUserObject() }.AsQueryable());
            _shoppingCartService.Setup(x => x.BuyArts("1"));

            // Act
            var service = new ShoppingCartService(_repo.Object);

            // Verify
            _shoppingCartService.Verify(x => x.BuyArts("1"), Times.Never);
        }

        [Fact]
        public void ClearCartAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ArtGalleryUser>()).Returns(new List<ArtGalleryUser> { ObjectGenerator.GetArtGalleryUserObject() }.AsQueryable());
            _shoppingCartService.Setup(x => x.ClearCartAsync("1"));

            // Act
            var service = new ShoppingCartService(_repo.Object);

            // Verify
            _shoppingCartService.Verify(x => x.ClearCartAsync("1"), Times.Never);
        }

        [Fact]
        public void GetArts_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ShoppingCartViewModel>()).Returns(new List<ShoppingCartViewModel> { ObjectGenerator.GetShoppingCartViewModelObject() }.AsQueryable());
            _shoppingCartService.Setup(x => x.GetArts("1"));

            // Act
            var service = new ShoppingCartService(_repo.Object);

            // Verify
            _shoppingCartService.Verify(x => x.GetArts("1"), Times.Never);
        }

        [Fact]
        public void IncreaseQuatity_Test()
        {
            // Assert
            _repo.Setup(x => x.All<ShoppingCartViewModel>()).Returns(new List<ShoppingCartViewModel> { ObjectGenerator.GetShoppingCartViewModelObject() }.AsQueryable());
            _shoppingCartService.Setup(x => x.IncreaseQuatity("1", true));

            // Act
            var service = new ShoppingCartService(_repo.Object);

            // Verify
            _shoppingCartService.Verify(x => x.IncreaseQuatity("1", true), Times.Never);
        }
    }
}
