namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models.Contarcts;
    using ArtGallery.Data.Models.Enumeration;

    public class EventOrder : IDeletableEntity
    {
        [Required]
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
        public decimal Price { get; set; }

        // Gallery should confirm the place of the user on the event. It depends from the available capacity for the event.
        public bool? Confirmed { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsDeleted { get ; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
