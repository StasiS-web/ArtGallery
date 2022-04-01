namespace ArtGallery.Web.ViewModels.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Services.Mapping.Contracts;
    using ArtGallery.Web.ViewModels.ArtStore;
    using Microsoft.AspNetCore.Http;
    using static ArtGallery.Common.GlobalConstants.ArtStore;
    using static ArtGallery.Common.GlobalConstants.DisplayNames;
    using static ArtGallery.Common.MessageConstants;

    public class ArtStoreCreateInputModel : IMapTo<ArtStoreViewModel>, IMapFrom<ArtStoreViewModel>
    {
        [Required]
        [MaxLength(PaintingNameMaxLenth)]
        [MinLength(PaintingNameMinLenth)]
        public string PaintingName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLenth)]
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
        [MaxLength(ArtsDescriptionMaxLenth)]
        public string Description { get; set; }
    }
}
