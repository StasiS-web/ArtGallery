using ArtGallery.Core.Contracts;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Test.Common;
using ArtGallery.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using System.Linq;
using ArtGallery.Tests.Common;

namespace ArtGallery.Tests
{
    public class UserServiceTests
    {
        private Mock<IAppRepository> _appRepository;
        private Mock<IUserService> _userService;


        public UserServiceTests()
        {
            _userService = new Mock<IUserService>();
            _appRepository = new Mock<IAppRepository>();
        }

        [Theory]
        [InlineData("testId")]
        public void GetAllUserShouldReturnUsersInDb(string userId)
        {

            // Assert.

            _appRepository.Setup(x => x.All<UserViewModel>()).Returns(ObjectGenerator.GetUserViewModelListObject().AsQueryable());
            _userService.Setup(x => x.GetAllUser(userId)).Returns(ObjectGenerator.GetUserViewModelListObject());

            // Act
            var services = new UserService(_appRepository.Object);

            services.GetAllUser(userId);

            // Verify
            _userService.Verify(x => x.GetAllUser(userId), Times.Never);
        }
    }
}
