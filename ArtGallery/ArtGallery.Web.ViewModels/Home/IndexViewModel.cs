namespace ArtGallery.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public List<UpcomingEventViewModel> AllUpcomingEvents { get; set; }

        public List<LatestBlogPostViewModel> AllLatestBlogPost { get; set; }
    }
}
