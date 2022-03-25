namespace ArtGallery.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;
    using Microsoft.AspNetCore.Http;

    public class LatestBlogPostViewModel : IMapFrom<Event>
    {
        public string Title { get; set; }

        public IFormFile UrlImage { get; set; }

        public string Content { get; set; }

        public string ShortContect
        {
            get
            {
                var shortContent = this.Content;
                return shortContent.Length > 50
                    ? shortContent.Substring(0, 50) + "..."
                    : shortContent;
            }
        }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string OnlyDate => this.CreatedOn.ToShortDateString();
    }
}
