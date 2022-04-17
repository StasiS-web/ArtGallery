namespace ArtGallery.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ArtStore : BaseDeletableModel<int>
    {
        public ArtStore()
        {
            this.SaleTransactions = new HashSet<SaleTransaction>();
        }

        [Required]
        [MaxLength(PaintingNameMaxLenth)]
        public string PaintingName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenth)]
        public string AuthorName { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ArtsDescriptionMaxLenth)]
        public string Description { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
