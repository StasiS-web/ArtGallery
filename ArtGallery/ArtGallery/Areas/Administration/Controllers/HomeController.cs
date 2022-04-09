using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
