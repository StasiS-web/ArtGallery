namespace ArtGallery.Core.Models.Administrator
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
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.MessageConstants;

    public class ArtStoreCreateInputModel 
    {
        [Required]
        [MaxLength(PaintingNameMaxLength)]
        [MinLength(PaintingNameMinLength)]
        public string PaintingName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string AuthorName { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string UrlImage { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [DataType(DataType.Upload)]
        [Display(Name = ProductImageDisplayName)]
        public IFormFile ArtImage { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ArtsDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
