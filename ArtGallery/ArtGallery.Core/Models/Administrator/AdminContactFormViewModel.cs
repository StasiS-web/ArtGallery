namespace ArtGallery.Core.Models.Administrator
{
    using ArtGallery.Core.Mapping.Contracts;
    using ArtGallery.Infrastructure.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ContactForm;

    public class AdminContactFormViewModel : IMapFrom<ContactForm>
    {
        [Required]
        [MaxLength( FullNameMaxLength)]
        [MinLength(FullNameMinLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        [MinLength(SubjectMinLength)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        [MinLength(MessageMinLength)]
        public string Message { get; set; }
    }
}
