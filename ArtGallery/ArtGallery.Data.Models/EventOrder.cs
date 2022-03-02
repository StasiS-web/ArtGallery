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
        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Event))]
        public string EventId { get; set; }

        public Event Event { get; set; }

        public EventType Type { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        // Gallery should confirm the place of the user on the event.
        public bool? Confirmed { get; set; }

        public PaymentMethod Payment { get; set; }

        public bool IsDeleted { get ; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
