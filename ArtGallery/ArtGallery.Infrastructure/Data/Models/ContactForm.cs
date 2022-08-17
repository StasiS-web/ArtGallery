namespace ArtGallery.Infrastructure.Data.Models
{
    using ArtGallery.Infrastructure.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ContactForm;

    public class ContactForm : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(FirstNameMaxLenth)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(LastNameMaxLenth)]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        public string Subject { get; init; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Message { get; init; }
    }
}
