namespace ArtGallery.Web.ViewModels.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class EventDetailsLookupModel : IHaveCustomMappings
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, EventDetailsLookupModel>()
                .ForMember(e => e.Date, opt => opt.MapFrom(src => src.CreatedOn.ToString(NormalDateFormat)));
        }
    }
}
