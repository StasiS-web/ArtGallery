namespace ArtGallery.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
