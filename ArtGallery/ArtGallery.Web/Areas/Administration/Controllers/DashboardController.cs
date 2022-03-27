using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
