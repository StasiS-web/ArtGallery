namespace ArtGallery.Infrastructure.Data.Models
{
    using ArtGallery.Infrastructure.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
       public string Name { get; set; }

       public string Value { get; set; }
    }
}
