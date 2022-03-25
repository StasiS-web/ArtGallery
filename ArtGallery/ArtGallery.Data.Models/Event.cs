namespace ArtGallery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.EventTickets = new HashSet<EventOrder>();
        }

        [MaxLength(EventNameMaxLenth)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        [ForeignKey(nameof(ExhibitionHall))]
        [Required]
        public int ExhibitionHallId { get; set; }

        public ExhibitionHall ExhibitionHall { get; set; }

        public TicketType TicketSelection { get; set; }

        [MaxLength(EventDescriptionMaxLenth)]
        public string Description { get; set; }

        /// <summary>
        /// Admin need to confirm or decline user booking.
        /// It depends from the capacity of the ExhibitionHall.
        /// </summary>

        public bool? Confirmed { get; set; }

        public ICollection<EventOrder> EventTickets { get; set; }
    }
}
