namespace ArtGallery.Core.Models.Administrator
{
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class EventCreateInputViewModel 
    {
        [MaxLength(EventNameMaxLenth)]
        [MinLength(EventNameMinLenth)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public string Date { get; set; }

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        [MaxLength(EventDescriptionMaxLenth)]
        [MinLength(EventDescriptionMinLength)]
        public string Description { get; set; }
    }
}
