using System.Diagnostics;
using ArtGallery.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtGallery.Web.Areas.Identity.Pages.Error
{
    public class Error404Model : PageModel
    {
        public void OnGet()
        {
        }

        private IActionResult View(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }

        [Route("~/Error/404")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            return this.View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
