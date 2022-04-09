namespace ArtGallery.Controllers
{
    using ArtGallery.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class ErrorController : BaseController
    {
        [Route("/Error/404")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            var errorModel = new ErrorViewModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier,
            };

            return View(errorModel);
        }

        [Route("/Error/500")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error500()
        {
            var errorModel = new ErrorViewModel
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier,
            };

            return View(errorModel);
        }
    }
}
