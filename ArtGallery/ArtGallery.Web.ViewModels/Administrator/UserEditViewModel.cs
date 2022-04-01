namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ArtGallery.Services.Mapping.Contracts;
    using ArtGallery.Web.ViewModels.Users;
    using static ArtGallery.Common.GlobalConstants.ArtGalleryUser;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;

    public class UserEditViewModel : IMapTo<UserViewModel>, IMapFrom<UserViewModel>
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
