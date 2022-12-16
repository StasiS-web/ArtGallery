
namespace ArtGallery.Core.Models.Events
{
    using ArtGallery.Core.Mapping.Contracts;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;

    public class EventViewModel 
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        public string Description { get; set; }

    }
}
