namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class SaleTransaction : BaseDeletableModel<string>
    {
        public SaleTransaction()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public SaleType SaleType { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        [ForeignKey(nameof(PaintingName))]
        public int ArtId { get; set; }

        [MaxLength(PaintingNameMaxLenth)]
        public ArtStore PaintingName { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
