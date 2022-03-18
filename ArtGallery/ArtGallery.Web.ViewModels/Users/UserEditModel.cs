namespace ArtGallery.Web.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using static ArtGallery.Common.GlobalConstants.ArtGalleryUser;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;

    public class UserEditModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(FullNameMaxLenth)]
        [MinLength(FullNaneMinLenth)]
        [Display(Name = FirstNameDisplayName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(FullNameMaxLenth)]
        [MinLength(FullNaneMinLenth)]
        [Display(Name = LastNameDisplayName)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        [MinLength(UsernameMinLength)]
        [Display(Name = UsernameDisplay)]
        public string UserName { get; set; }
    }
}
