
namespace ArtGallery.Core.Models.Users
{
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;

    public class ProfileViewModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public Gender Gender { get; set; }

        public string UrlImage { get; set; }

        public IFormFile Photo { get; set; }

        public string Email { get; set; }

    }
}
