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
        private readonly IEventService _eventService;
        private readonly IBlogPostService _blogPostService;
        // private readonly IContactsService contactsService;

        public HomeController(ILogger<HomeController> logger, IEventService eventService,
           IBlogPostService blogPostService)
        {
            this.logger = logger;
            this._eventService = eventService;
            this._blogPostService = blogPostService;
            // this.contactsService = contactsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int eventId, int blogId)
        {
            var upcomingEvents = await _eventService.GetUpcomingByIdAsync<UpcomingEventViewModel>(eventId);
            var latestBlog = await _blogPostService.GetLatestBlogAsync<LatestBlogPostViewModel>(blogId);

            var latestBlogs = latestBlog.Select(x => new LatestBlogPostViewModel()
            {
                Author = x.Author,
                Content = x.Content,
                Title = x.Title,
                UrlImage = x.UrlImage
            }).ToList();

            ViewBag.AllUpcomingEvents = upcomingEvents;
            ViewBag.AllLatestBlogPost = latestBlogs;

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