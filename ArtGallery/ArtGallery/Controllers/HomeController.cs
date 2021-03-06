namespace ArtGallery.Controllers
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.Contacts;
    using ArtGallery.Core.Models.Home;
    using ArtGallery.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
       // private readonly IEventService eventService;
       // private readonly IBlogPostService blogPostService;
       // private readonly IContactsService contactsService;
     
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            //this.eventService = eventService;
           // this.blogPostService = blogPostService;
           // this.contactsService = contactsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int eventId, int blogId)
        {
          // var upcomingEvents = await eventService.GetUpcomingByIdAsync<UpcomingEventViewModel>(eventId);
         //  var latestBlog = await blogPostService.GetLatestBlogAsync<LatestBlogPostViewModel>(blogId);

          // ViewBag.AllUpcomingEvents = upcomingEvents;
          // ViewBag.AllLatestBlogPost = latestBlog;

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

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    SameSite = SameSiteMode.Strict
                });

            return LocalRedirect(returnUrl);
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost("Home/Contacts")]
        public async Task<IActionResult> Contacts(ContactFormViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                return View(model);
            }

         //   await this.contactsService.ConatctAdmin(model);
            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}