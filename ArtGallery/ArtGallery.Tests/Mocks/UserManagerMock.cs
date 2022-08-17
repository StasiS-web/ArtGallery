namespace ArtGallery.Tests.Mocks
{
    using ArtGallery.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Moq;

    public class UserManagerMock
    {
        public static Mock<UserManager<ArtGalleryUser>> New
            => new Mock<UserManager<ArtGalleryUser>>(
                Mock.Of<IUserStore<ArtGalleryUser>>(), null, null, null, null, null, null, null, null);
    }
}
