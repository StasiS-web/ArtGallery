namespace ArtGallery.Web.ViewModels.Search
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class EventLookupModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
