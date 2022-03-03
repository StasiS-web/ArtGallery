namespace ArtGallery.Web.ViewModels.Events
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class EventViewModel : IMapFrom<Event>
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Date { get; set; }

        public string Type { get; set; }

        public int ExhibitionHallId { get; set; }

        public string ExhibitionHall { get; set; }

        public string TicketType { get; set; }

        public string Description { get; set; }
    }
}
