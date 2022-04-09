using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
