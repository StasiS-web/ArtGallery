namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ArtStoreCreateInputModel
    {
        [Required]
        [MaxLength(PaintingNameMaxLenth)]
        [MinLength(PaintingNameMinLenth)]
        public string PaintingName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenth)]
        public string AuthorName { get; set; }

        [Required]
        public IFormFile UrlImage { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ArtsDescriptionMaxLenth)]
        public string Description { get; set; }
    }
}
