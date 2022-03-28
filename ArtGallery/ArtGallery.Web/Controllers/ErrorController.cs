using System.Diagnostics;
using ArtGallery.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace ArtGallery.Web.Controllers
{
    public class ErrorController : BaseController
    {
        [Route("/Error/Error")]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

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
