namespace ArtGallery.Core.Models.Users
{

    public class UserRolesViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> RoleNames { get; set; }
    }
}
