namespace ArtGallery.Web.ViewModels.Users
{
    using ArtGallery.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Http;

    public class UserViewModel
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
