namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using static ArtGallery.Common.GlobalConstants.ArtGalleryUser;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;

    public class UserEditViewModel
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
    }
}
