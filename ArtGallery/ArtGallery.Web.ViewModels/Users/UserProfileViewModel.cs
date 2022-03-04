using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Web.ViewModels.Users
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "FullNameDisplayName")]
        public string FullName { get; set; }

        public string Gender { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [Display(Name = "UsernameDisplay")]
        public string Username { get; set; }

        public string Image { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "EmailDisplay")]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
