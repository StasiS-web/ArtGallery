namespace ArtGallery.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;

    public class LoginInputViewModel
    {
        [Required]
        [Display(Name = UsernameDisplay)]
        public string Username { get; set; }

        [Required]
        [Display(Name = PasswordDisplay)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}