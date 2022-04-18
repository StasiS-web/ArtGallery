namespace ArtGallery.Core.Models.Contacts
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.ContactForm;
    using static ArtGallery.Common.MessageConstants;

    public class SendContactInputViewModel
    { 
        [Required(ErrorMessage = FullNameLength)]
        [Display(Name = FullNameDisplay)]
        [MaxLength(FullNameMaxLength)]
        [MinLength(FullNameMinLength)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = EmailDisplay)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        [MinLength(SubjectMinLength)]
        public string Subject { get; set; }

        [Required]
        [Display(Name = MessageDisplay)]
        [MaxLength(MessageMaxLength)]
        [MinLength(MessageMinLength)]
        public string Message { get; set; }

        public IEnumerable<UserEmailViewModel> UserEmails { get; set; }
    }
}
