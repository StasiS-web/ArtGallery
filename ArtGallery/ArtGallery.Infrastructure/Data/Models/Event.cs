namespace ArtGallery.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.Event;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.BookingTransactions = new HashSet<BookingTransaction>();
        }

        [MaxLength(EventNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; } = DateTime.Today;

        public EventType Type { get; set; }

        public TicketType TicketSelection { get; set; }

        [MaxLength(EventDescriptionMaxLength)]
        public string Description { get; set; }

        /// <summary>
        /// Admin need to confirm or decline user booking.
        /// It depends from the capacity of the ExhibitionHall.
        /// </summary>
        public bool? Confirmed { get; set; }

        public ICollection<BookingTransaction> BookingTransactions { get; set; }
    }
}
