
namespace ArtGallery.Core.Models.Administrator
{
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Core.Mapping.Contracts;
    public class FaqDeleteViewModel : IMapFrom<FaqEntity>
    {
        public int FaqId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

    }
}
