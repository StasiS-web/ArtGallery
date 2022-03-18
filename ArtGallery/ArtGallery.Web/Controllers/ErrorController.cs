using System.Diagnostics;
using ArtGallery.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace ArtGallery.Web.Controllers
{
    public class ErrorController : BaseController
    {

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [Route("/Error/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            return this.View();
        }

        [Route("~/Error/404")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            return this.View(new ErrorViewModel
                { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [Route("~/Error/500")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error500()
        {
            return this.View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
