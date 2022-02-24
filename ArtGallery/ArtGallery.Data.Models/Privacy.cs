namespace ArtGallery.Data.Models
{ 
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.Privacy;

    public class Privacy : BaseDeletableModel<int>
    {
      [Required]
      [MaxLength(PageContentMaxLength)]
      public string PageContent { get; set; }
    }
}
