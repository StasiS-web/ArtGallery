namespace ArtGallery.Core.Models.Contacts
{
    using ArtGallery.Core.Mapping.Contracts;
    using ArtGallery.Infrastructure.Data.Models;
    public class UserEmailViewModel : IMapFrom<ContactForm>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
