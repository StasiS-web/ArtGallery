namespace ArtGallery.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ArtGalleryUser;

    public class LoginInputViewModel
    {
        [Required]
        [Display(Name = UsernameDisplay)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}