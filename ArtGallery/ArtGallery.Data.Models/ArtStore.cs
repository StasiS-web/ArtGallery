namespace ArtGallery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ArtStore : BaseDeletableModel<string>
    {
        public ArtStore()
        {
            this.ArtOrders = new HashSet<ArtOrder>();
        }

        [MaxLength(PaintingNameMaxLenth), Required]
        public string PaintingName { get; set; }

        [MaxLength(AuthorNameMaxLenth), Required]
        public string AuthorName { get; set; }

        [Range(PriceMinLength, PriceMaxLength), Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [MaxLength(DescriptionMaxLenth), Required]
        public string Description { get; set; }

        public ICollection<ArtOrder> ArtOrders { get; set; }
    }
}
