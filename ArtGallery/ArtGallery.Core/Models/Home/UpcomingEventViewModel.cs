namespace ArtGallery.Core.Models.Home
{
    using ArtGallery.Infrastructure.Data.Models.Enumeration;

    public class UpcomingEventViewModel 
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public decimal Price { get; set; }

        public EventType Type { get; set; }

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
