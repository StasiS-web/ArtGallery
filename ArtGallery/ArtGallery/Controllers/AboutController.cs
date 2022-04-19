using ArtGallery.Core.Models.FaqEntity;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var faq = aboutService.GetAllFaqsAsync<FaqViewModel>();

            return View(faq);
        }
    }
}
