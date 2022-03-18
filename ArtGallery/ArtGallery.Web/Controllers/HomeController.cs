namespace ArtGallery.Web.Controllers
{
    using System.Diagnostics;
    using ArtGallery.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using static ArtGallery.Common.MessageConstants;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this.ViewData[MessageConstants.OperationalMessages] = SuccessfullyRunningToaster;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}