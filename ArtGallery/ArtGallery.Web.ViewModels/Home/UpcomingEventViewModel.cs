namespace ArtGallery.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class UpcomingEventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public decimal Price { get; set; }

        public EventType Type { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var shortDescription = this.Description;
                return shortDescription.Length > 100
                    ? shortDescription.Substring(0, 100) + "..."
                    : shortDescription;
            }
        }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, UpcomingEventViewModel>()
                 .ForMember(e => e.Date, opt => opt.MapFrom(src => src.CreatedOn.ToString(NormalDateFormat)));
        }
    }
}
