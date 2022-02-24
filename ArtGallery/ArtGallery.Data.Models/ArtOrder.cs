namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ArtOrder : IDeletableEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        public int ArtId { get; set; }

        [MaxLength(PaintingNameMaxLenth)]
        public string PaintingName { get; set; }

        public int Quantity { get; set; }

        [Range(PriceMinLength, PriceMaxLength), Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
