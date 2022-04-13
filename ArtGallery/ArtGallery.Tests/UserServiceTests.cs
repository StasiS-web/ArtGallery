using ArtGallery.Areas.Administration.Controllers;
using ArtGallery.Core.Contracts;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Test.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArtGallery.Tests
{
    public class UserServiceTests
    {
        public Mock<IUserService> userMock = new Mock<IUserService>();
        
        [Fact]
        public async Task GetAllUserShouldReturnUsersInDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllUsers")
                .Options;
            var dbContext = new ApplicationDbContext(options);

            var user1 = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin123",
                FirstName = "Admin",
                LastName = "LastAdmin"
            };

            var user2 = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin223",
                FirstName = "Admin2",
                LastName = "LastAdmin2"
            };

            dbContext.Users.Add(user1);
            dbContext.Users.Add(user2);
            dbContext.SaveChanges();

            var userManager = MockUserManager<ApplicationUser>();
           // var userService = new UserService(userManager.Object, dbContext);
            var expected = new List<string> { user1.UserName, user2.UserName };
          //  var result = userService.GetIdByUsername().Select(x => x.UserName).ToList();

          //  Assert.Equal(expected, result);
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
