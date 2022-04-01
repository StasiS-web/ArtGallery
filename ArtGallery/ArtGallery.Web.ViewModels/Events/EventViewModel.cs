namespace ArtGallery.Web.ViewModels.Events
{
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;

    public class EventViewModel : IMapFrom<Event>
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string TicketSelection { get; set; }

        public string Description { get; set; }

        public bool? Confirmed { get; set; }
    }
}
