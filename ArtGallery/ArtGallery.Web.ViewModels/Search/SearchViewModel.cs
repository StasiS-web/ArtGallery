namespace ArtGallery.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchViewModel
    {
        public string SearchQuery { get; set; }

        public IEnumerable<EventLookupModel> Events { get; set; }

        public IEnumerable<BlogPostLookupModel> BlogPosts { get; set; }
    }
}
