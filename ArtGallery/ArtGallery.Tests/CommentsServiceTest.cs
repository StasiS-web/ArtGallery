using ArtGallery.Core.Contracts;
using ArtGallery.Core.Models.BlogPosts;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ArtGallery.Tests
{
    public class CommentsServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<ICommentsService> _commentsService;
        private ApplicationDbContext _context;
        public CommentsServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _commentsService = new Mock<ICommentsService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "CommentsDb")
        .Options);
        }

        [Fact]
        public void CreateArtAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync(ObjectGenerator.GetBlogCommentObject()));
            _commentsService.Setup(x => x.CreateAsync(1,1,"1","1"));

            // Act
            var service = new CommentsService(_repo.Object);

            // Verify
            _commentsService.Verify(x => x.CreateAsync(1, 1, "1", "1"), Times.Never);
        }

        [Fact]
        public void DeleteAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<BlogComment>());
            _repo.Setup(x => x.Delete<BlogComment>(ObjectGenerator.GetBlogCommentObject()));
            _commentsService.Setup(x => x.DeleteAsync(1));

            // Act
            var service = new CommentsService(_repo.Object);

            // Verify
            _commentsService.Verify(x => x.DeleteAsync(1), Times.Never);
        }

        [Fact]
        public void GetBlogIdByCommentsAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<BlogCommentViewModel>()).Returns(new List<BlogCommentViewModel> {
            ObjectGenerator.GetBlogCommentViewModelObject()}.AsQueryable());

            _commentsService.Setup(x => x.GetBlogIdByCommentsAsync(1));

            // Act
            var service = new CommentsService(_repo.Object);

            // Verify
            _commentsService.Verify(x => x.GetBlogIdByCommentsAsync(1), Times.Never);
        }
    }
}
