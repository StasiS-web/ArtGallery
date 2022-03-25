namespace ArtGallery.Web.ViewModels.Events
{
    using ArtGallery.Data.Models.Enumeration;

    public class AllEventListViewModel
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        public string Description { get; set; }
    }
}
