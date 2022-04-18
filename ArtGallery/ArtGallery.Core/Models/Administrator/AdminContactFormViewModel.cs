namespace ArtGallery.Core.Models.Administrator
{
    using ArtGallery.Core.Mapping.Contracts;
    using ArtGallery.Infrastructure.Data.Models;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ContactForm;

    public class AdminContactFormViewModel : IHaveCustomMappings
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AdminContactFormViewModel, ContactForm>()
                 .ForMember(des => $"{des.FirstName} {des.LastName}", opts => opts.MapFrom(x => x.FullName));
        }
    }
}
