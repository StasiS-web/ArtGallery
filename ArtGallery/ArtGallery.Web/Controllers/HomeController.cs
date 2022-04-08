namespace ArtGallery.Web.Controllers
{
    using System.Collections.Generic;
    using ArtGallery.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static ArtGallery.Common.GlobalConstants.SeededDataCounts;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService eventService;
        private readonly IBlogPostService blogService;

        public HomeController(ILogger<HomeController> _logger, IEventService eventService, IBlogPostService blogService)
        {
            this._logger = _logger;
            this.eventService = eventService;
            this.blogService = blogService;
        }

        [HttpGet("/")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            this.ViewData[MessageConstants.OperationalMessage] = "Well done, you manage to drive the tostr!";

            var upcomingEvents = (IEnumerable<IndexViewModel>)this.eventService.GetUpcomingByIdAsync<UpcomingEventViewModel>(UpcomingEventCount);
            var latestBlog = this.blogService.GetLatestBlogAsync<LatestBlogPostViewModel>(LatestBlogCount);

            var modelView = new IndexViewModel
             {
                 AllUpcomingEvents = (IEnumerable<UpcomingEventViewModel>)upcomingEvents,
                 AllLatestBlogPost = (IEnumerable<LatestBlogPostViewModel>)latestBlog,
             };

            return View(modelView);
        }

        [HttpPost]
        public async Task<IActionResult> Index([ModelBinder(typeof(DateTimeModelBinder))] IndexViewModel model)
        {

            return Ok(model);
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
