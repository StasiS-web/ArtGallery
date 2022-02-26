namespace ArtGallery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.EventTickets = new HashSet<EventOrder>();
        }

        [MaxLength(EventNameMaxLenth)]
        public string Name { get; set; }

        [Range(PriceMinLenth, PriceMaxLenth)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public EventType Type { get; set; }

        [ForeignKey(nameof(ExhibitionHall)), Required]
        public int ExhibitionHallId { get; set; }

        public ExhibitionHall ExhibitionHall { get; set; }

        public TicketType TicketType { get; set; }

        [MaxLength(DescriptionMaxLenth)]
        public string Description { get; set; }

        public ICollection<EventOrder> EventTickets { get; set; }

    }
}
