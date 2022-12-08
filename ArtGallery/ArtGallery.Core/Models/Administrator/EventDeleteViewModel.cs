namespace ArtGallery.Core.Models.Administrator
{
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Core.Mapping.Contracts;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EventDeleteViewModel : IMapFrom<Event>
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Date { get; set; }

        public EventType Type { get; set; }

        public List<SelectListItem> EventType { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "InPerson" },
            new SelectListItem { Value = "2", Text = "Online" },
        };

        public TicketType TicketSelection { get; set; }

        public List<SelectListItem> TicketType { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Free" },
            new SelectListItem { Value = "2", Text = "Paid" },
        };


        public string Description { get; set; }
    }
}
