namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class EventCreateInputViewModel
    {
        [MaxLength(EventNameMaxLenth)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public string Date { get; set; }

        public EventType Type { get; set; }

        [ForeignKey(nameof(ExhibitionHall))]
        [Required]
        public int ExhibitionHallId { get; set; }

        public string ExhibitionHall { get; set; }

        public TicketType TicketType { get; set; }

        [MaxLength(EventDescriptionMaxLenth)]
        public string Description { get; set; }
    }
}
