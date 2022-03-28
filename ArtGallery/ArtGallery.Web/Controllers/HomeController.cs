namespace ArtGallery.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Dynamic;
    using ArtGallery.Web.ViewModels;
    using ArtGallery.Web.ViewModels.BlogPosts;
    using ArtGallery.Web.ViewModels.Events;
    using ArtGallery.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using static ArtGallery.Common.GlobalConstants;
    using static ArtGallery.Common.MessageConstants;

    public class HomeController : BaseController
    {
        private readonly IEventService eventService;
        private readonly IBlogPostService blogPostService;

        public HomeController(IEventService eventService, IBlogPostService blogPostService)
        {
            this.eventService = eventService;
            this.blogPostService = blogPostService;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            this.ViewData[MessageConstants.OperationalMessages] = SuccessfullyRunningToaster;

            dynamic model = new ExpandoObject();
            var modelView = new IndexViewModel
            {
                AllUpcomingEvents = this.eventService.GetUpcomingByIdAsync<EventViewModel>(model.eventService.EventId),
                AllLatestBlogPost = this.blogPostService.GetLatestBlogAsync(model.blogPostService.BlogId),
            };

            return View(modelView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Home/{code:int}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? code = null)
        {
            if (code == StatusCodes.Status404NotFound)
            {
                return Redirect($"/Error/{StatusCodes.Status404NotFound}");
            }

            return Redirect($"/Error/{StatusCodes.Status500InternalServerError}");
        }

    }
}
