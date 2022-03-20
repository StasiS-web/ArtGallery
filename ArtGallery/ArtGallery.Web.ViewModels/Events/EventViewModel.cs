namespace ArtGallery.Web.ViewModels.Events
{
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;

    public class EventViewModel : IMapFrom<Event>
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        public int ExhibitionHallId { get; set; }

        public string ExhibitionHall { get; set; }

        public TicketType TicketType { get; set; }

        public string Description { get; set; }

        public bool? Confirmed { get; set; }
    }
}
