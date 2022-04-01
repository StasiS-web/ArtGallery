namespace ArtGallery.Web.ViewModels.Events
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class EventViewModel : IMapTo<Event>, IMapFrom<Event>
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string TicketSelection { get; set; }

        public string Description { get; set; }
    }
}
