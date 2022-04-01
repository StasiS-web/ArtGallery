namespace ArtGallery.Web.ViewModels.ArtStore
{
    public class AllArtListViewModel
    {
        public IEnumerable<ArtStoreViewModel> AllArts { get; set; }

        public int ArtId { get; set; }

        public string PaintingName { get; set; }

        public string AuthorName { get; set; }

        public string UrlImage { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var shortDescription = this.Description;
                return shortDescription.Length > 100
                    ? shortDescription.Substring(0, 100) + "..."
                    : shortDescription;
            }
        }
    }
}
