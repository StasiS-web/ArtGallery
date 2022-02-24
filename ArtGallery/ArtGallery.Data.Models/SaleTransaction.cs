namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;

    public class SaleTransaction : BaseDeletableModel<string>
    {
        public SaleType SaleType { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Event))]
        public string EventId { get; set; }

        public Event Event { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
