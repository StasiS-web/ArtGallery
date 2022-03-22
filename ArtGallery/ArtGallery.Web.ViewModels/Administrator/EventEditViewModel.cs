namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class EventEditViewModel
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
        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketType { get; set; }

        [MaxLength(EventDescriptionMaxLenth)]
        [MinLength(EventDescriptionMinLength)]
        public string Description { get; set; }
    }
}
