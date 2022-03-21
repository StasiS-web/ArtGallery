using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
