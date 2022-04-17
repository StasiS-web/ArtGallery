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

namespace ArtGallery.Tests
{
    public class UserServiceTests
    {
        [Theory]
        [InlineData("testId")]
        public async Task GetAllUserShouldReturnUsersInDb(string userId)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

           var context = new ApplicationDbContext(options);
           //var services = serviceProvider.GetService<IUserService>();

            context.Add( new List<ArtGalleryUser>()
                    {
                       new ArtGalleryUser
                       {
                            Id = Guid.NewGuid().ToString(),
                            UserName = "admin123",
                            FirstName = "Admin",
                            LastName = "LastAdmin"
                        },
                       new ArtGalleryUser
                       {
                            Id = Guid.NewGuid().ToString(),
                            UserName = "admin223",
                            FirstName = "Admin2",
                            LastName = "LastAdmin2"
                       }
                    });
            var repo = new AppRepository(context);
            var services = new UserService(repo);

            var users = new List<ArtGalleryUser>();
            users.Add(new ArtGalleryUser { FirstName = "test", LastName = "lastTest", UserName = "userTest" });
            var actual = services.GetAllUser(userId);
          
            Assert.True(actual.Count() == users.Count);
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

    }
}
