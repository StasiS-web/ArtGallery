namespace ArtGallery.Web.ViewModels.Users
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;
    using Microsoft.AspNetCore.Http;

    public class UserViewModel : IMapTo<ArtGalleryUser>, IMapFrom<ArtGalleryUser>
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Gender { get; set; }

        public IFormFile UrlImage { get; set; }

        public string Email { get; set; }
    }
}
