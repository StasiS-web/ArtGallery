namespace ArtGallery.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using ArtGallery.Web.ViewModels;
    using ArtGallery.Web.ViewModels.Events;
    using ArtGallery.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using static ArtGallery.Common.GlobalConstants;
    using static ArtGallery.Common.MessageConstants;

    public class HomeController : BaseController
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly IEventService eventService;
        private readonly IBlogPostService blogPostService;

        public HomeController(ILogger<HomeController> logger, IEventService eventService, IBlogPostService blogPostService)
        {
            this.eventService = eventService;
            this.blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            this.ViewData[MessageConstants.OperationalMessages] = SuccessfullyRunningToaster;

            return View();
        }

        [HttpGet("/Home/Index")]
        public IActionResult ListUpcomingEvents()
        {
            var upcomingEvents = new IndexViewModel()
            {
               AllUpcomingEvents = (IEnumerable<UpcomingEventViewModel>)this.eventService.GetUpcomingByIdAsync<UpcomingEventViewModel>(SeededDataCounts.Events),
            };

            return View(upcomingEvents);
        }

        [HttpPost]
        public IActionResult ListUpcomingEvents(UpcomingEventViewModel model)
        {
            return Ok(model);
        }

        [HttpGet("/Home/Index")]
        public IActionResult LatestBlogPost()
        {
            var latestBlogPost = new IndexViewModel()
            {
                AllLatestBlogPost = (IEnumerable<LatestBlogPostViewModel>)this.blogPostService.GetLatestBlogAsync(SeededDataCounts.BlogPost),
            };

            if (latestBlogPost == null)
            {
                throw new ArgumentNullException(LatestPost);
            }

            return View(latestBlogPost);
        }

        [HttpPost]
        public IActionResult LatestBlogPost(LatestBlogPostViewModel model)
        {
            return Ok(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
