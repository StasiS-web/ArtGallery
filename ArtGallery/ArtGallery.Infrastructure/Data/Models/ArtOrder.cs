namespace ArtGallery.Infrastructure.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models.Contracts;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ArtOrder : IDeletableEntity
    {
        public ArtOrder()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderDate = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        [Required]
        [ForeignKey(nameof(PaintingName))]
        public int ArtId { get; set; }

        [MaxLength(PaintingNameMaxLenth)]
        public ArtStore PaintingName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
