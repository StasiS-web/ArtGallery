namespace ArtGallery.Web.ViewModels.Search
{
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;

    public class BlogPostLookupModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
