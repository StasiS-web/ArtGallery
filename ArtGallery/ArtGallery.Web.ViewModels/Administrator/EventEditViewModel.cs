namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;
    using ArtGallery.Web.ViewModels.Events;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class EventEditViewModel : IMapTo<EventViewModel>, IMapFrom<EventViewModel>
    {
        public int EventId { get; set; }

        [Required]
        [MaxLength(EventNameMaxLenth)]
        [MinLength(EventNameMinLenth)]
        [Display(Name = EventNameDisplay)]
        public string Name { get; set; }

        [Required]
        [Range(PriceMax, PriceMin)]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public string Date { get; set; }

        // In the view need to use a list from enum class to display the event type
        public EventType Type { get; set; }

        public List<SelectListItem> EventType { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "InPerson" },
            new SelectListItem { Value = "2", Text = "Online" },
        };

        // In the view need to use a list from enum class to display the ticket type
        public TicketType TicketSelection { get; set; }

        public List<SelectListItem> TicketType { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Free" },
            new SelectListItem { Value = "2", Text = "Paid" },
        };

        [MaxLength(EventDescriptionMaxLenth)]
        [MinLength(EventDescriptionMinLength)]
        public string Description { get; set; }

    }
}
