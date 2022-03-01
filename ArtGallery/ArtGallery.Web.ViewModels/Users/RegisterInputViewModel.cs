namespace ArtGallery.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ArtGalleryUser;
    public class RegisterInputViewModel
    {
        [Required]
        [MaxLength(FullNameMinLenth)]
        [MinLength(FullNameMinLenth)]
        [Display(Name = FullNameDisplayName)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = UsernameDisplay)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = EmailDisplay)]
        public string Email { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = PasswordDisplay)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = ConfirmPasswordDisplay)]

        public string ConfirmPassword { get; set; }
    }
}
