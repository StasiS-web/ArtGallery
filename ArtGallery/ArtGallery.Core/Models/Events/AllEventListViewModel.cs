﻿namespace ArtGallery.Core.Models.Events
{
    using ArtGallery.Infrastructure.Data.Models.Enumeration;

    public class AllEventListViewModel
    {
        public IEnumerable<EventViewModel> AllEvents { get; set; }

        public int EventId { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var shortDescription = this.Description;
                if (this.Description != null)
                {
                    return shortDescription
                        .Length > 100
                        ? shortDescription.Substring(0, 100) + "..."
                        : shortDescription;
                }
                return shortDescription;
            }
        }
    }
}
