namespace ArtGallery.Core.Models.Contacts
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ContactForm;
    using static ArtGallery.Common.MessageConstants;

    public class ContactFormViewModel
    {
        [Required(ErrorMessage = FirstNameError)]
        [MaxLength(FirstNameMaxLenth)]
        [MinLength(FirstNameMinLenth)]
        public string FirstName { get; init; }

        [Required(ErrorMessage = LastNameError)]
        [MaxLength(LastNameMaxLenth)]
        [MinLength(LastNameMinLenth)]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required(ErrorMessage = SubjectLength)]
        [MaxLength(SubjectMaxLength)]
        [MinLength(SubjectMinLength)]
        public string Subject { get; init; }

        [Required(ErrorMessage = MessageLength)]
        [MaxLength(MessageMaxLength)]
        [MinLength(MessageMinLength)]
        public string Message { get; init; }

        public static IEnumerable<SelectListItem> Subjects { get; }
               = new List<SelectListItem>
               {
                   new("Please select subject...", null, true, true),
                   new("General Enquiry", "General Enquiry"),
                   new("Question", "Question"),
                   new("Feedback", "Feedback"),
                   new("Other", "Other"),
               }.AsReadOnly();
    }
}
