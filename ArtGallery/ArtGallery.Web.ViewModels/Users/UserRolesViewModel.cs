namespace ArtGallery.Web.ViewModels.Users
{
    using ArtGallery.Data.Models.Enumeration;

    public class UserRolesViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string[] RoleIds { get; set; }
    }
}
