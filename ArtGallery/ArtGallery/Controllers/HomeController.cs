namespace ArtGallery.Controllers
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.Home;
    using ArtGallery.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
       // private readonly IEventService eventService;
       // private readonly IBlogPostService blogPostService;
        public HomeController()
        {
          //  this.eventService = eventService;
           // this.blogPostService = blogPostService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
           // var upcomingEvents = eventService.GetUpcomingByIdAsync<UpcomingEventViewModel>(eventId);
           // var latestBlog = blogPostService.GetLatestBlogAsync<LatestBlogPostViewModel>(blogId);

           // ViewBag.AllUpcomingEvents = (IEnumerable<UpcomingEventViewModel>)upcomingEvents;
          //  ViewBag.AllLatestBlogPost = (IEnumerable<LatestBlogPostViewModel>)latestBlog;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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