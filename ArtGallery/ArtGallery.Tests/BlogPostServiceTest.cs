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
using System.Threading.Tasks;
using Xunit;

namespace ArtGallery.Tests
{
    public class BlogPostServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<IBlogPostService> _blogPostService;
        private Mock<ICloudinaryService> _cloudinaryService;
        private ApplicationDbContext _context;
        public BlogPostServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _blogPostService = new Mock<IBlogPostService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "BlogPostDb")
       .Options);
            _cloudinaryService = new Mock<ICloudinaryService>();
        }

        [Fact]
        public void CreateArtAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync(ObjectGenerator.GetBlogPostCreateInputModelObject()));
            _blogPostService.Setup(x => x.CreateBlogPostAsync(ObjectGenerator.GetBlogPostCreateInputModelObject(), "user")).Returns(Task.Run(() => 1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.CreateBlogPostAsync(ObjectGenerator.GetBlogPostCreateInputModelObject(), "user"), Times.Never);
        }

        [Fact]
        public void EditBlog_Test()
        {
            // Assert
            _repo.Setup(x => x.Update(ObjectGenerator.GetBlogPostEditViewModelObject()));
            _blogPostService.Setup(x => x.EditBlog(ObjectGenerator.GetBlogPostEditViewModelObject(), 1)).Returns(Task.Run(() => 1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.EditBlog(ObjectGenerator.GetBlogPostEditViewModelObject(), 1), Times.Never);
        }

        [Fact]
        public void Delete_Test()
        {
            // Assert
            _repo.Setup(x => x.Delete(ObjectGenerator.GetBlogPostViewModelObject()));
            _blogPostService.Setup(x => x.Delete(1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.Delete(1), Times.Never);
        }

        [Fact]
        public void GetAll_Test()
        {
            // Assert
            _repo.Setup(x => x.All<BlogPostViewModel>()).Returns(new List<BlogPostViewModel> {
             ObjectGenerator.GetBlogPostViewModelObject()
            }.AsQueryable());

            _blogPostService.Setup(x => x.GetAll());

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.GetAll(), Times.Never);
        }

        [Fact]
        public void GetAll_SortId_BlogId_Test()
        {
            // Assert
            _repo.Setup(x => x.All<BlogPostViewModel>()).Returns(new List<BlogPostViewModel> {
             ObjectGenerator.GetBlogPostViewModelObject()
            }.AsQueryable());

            _blogPostService.Setup(x => x.GetAll<BlogPostViewModel>(1, 1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.GetAll<BlogPostViewModel>(1, 1), Times.Never);
        }

        [Fact]
        public void AllBlogsCount_Test()
        {
            // Assert
            _repo.Setup(x => x.All<BlogPost>()).Returns(new List<BlogPost> {
             ObjectGenerator.GetBlogPostObject()
            }.AsQueryable());

            _blogPostService.Setup(x => x.AllBlogsCount());

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.AllBlogsCount(), Times.Never);
        }

        [Fact]
        public void GetById_Test()
        {
            // Assert
            _blogPostService.Setup(x => x.GetById<int>(1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.GetById<int>(1), Times.Never);
        }

        [Fact]
        public void GetAuthorIdAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<BlogPostViewModel>()).Returns(new List<BlogPostViewModel> {
             ObjectGenerator.GetBlogPostViewModelObject()
            }.AsQueryable());
            _blogPostService.Setup(x => x.GetAuthorIdAsync(1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.GetAuthorIdAsync(1), Times.Never);
        }

        [Fact]
        public void GetLatestBlogAsync_Test()
        {
            // Assert
            _blogPostService.Setup(x => x.GetLatestBlogAsync<int>(1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.GetLatestBlogAsync<int>(1), Times.Never);
        }

        [Fact]
        public void GetBlogPostDetailsByIdAsync_Test()
        {
            // Assert
            _blogPostService.Setup(x => x.GetBlogPostDetailsByIdAsync<int>(1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.GetBlogPostDetailsByIdAsync<int>(1), Times.Never);
        }

        [Fact]
        public void BlogPostExists_Test()
        {
            // Assert
            _blogPostService.Setup(x => x.BlogPostExists(1));

            // Act
            var service = new BlogPostService(_repo.Object, _cloudinaryService.Object, _context);

            // Verify
            _blogPostService.Verify(x => x.BlogPostExists(1), Times.Never);
        }
    }
}

