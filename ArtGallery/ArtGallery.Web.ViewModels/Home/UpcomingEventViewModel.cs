namespace ArtGallery.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;

    public class UpcomingEventViewModel : IMapFrom<Event>
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public EventType Type { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var shortDescription = this.Description;
                return shortDescription.Length > 20
                    ? shortDescription.Substring(0, 20) + "..."
                    : shortDescription;
            }
        }
    }
}
