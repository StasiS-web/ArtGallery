﻿namespace ArtGallery.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;

    public class BookingTransaction : BaseDeletableModel<string>
    {
        public BookingTransaction()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public SaleType SaleType { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public EventType Type { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
