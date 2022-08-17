namespace ArtGallery.Infrastructure.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models.Contracts;
    using static ArtGallery.Common.GlobalConstants.Event;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;

    public class EventOrder : IDeletableEntity
    {
        public EventOrder()
        {
            this.Id = Guid.NewGuid().ToString();
            this.BookingDate = DateTime.Now;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime BookingDate { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        // Gallery should confirm the place of the user on the event. It depends from the available capacity for the event.
        public bool? Confirmed { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsDeleted { get ; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
