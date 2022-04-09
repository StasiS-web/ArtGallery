namespace ArtGallery.Core.Models.Home
{
    using System;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<UpcomingEventViewModel> AllUpcomingEvents { get; set; }

        public IEnumerable<LatestBlogPostViewModel> AllLatestBlogPost { get; set; }
    }
}
