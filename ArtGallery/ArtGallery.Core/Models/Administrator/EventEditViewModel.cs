namespace ArtGallery.Core.Models.Administrator
{
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class EventEditViewModel
    {
        public int EventId { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        [MinLength(EventNameMinLength)]
        [Display(Name = EventNameDisplay)]
        public string Name { get; set; }

        // Code changes by bhavin.

        [Required]
        [Range(PriceMin, PriceMax)]
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

        [MaxLength(EventDescriptionMaxLength)]
        [MinLength(EventDescriptionMinLength)]
        public string Description { get; set; }

    }
}
