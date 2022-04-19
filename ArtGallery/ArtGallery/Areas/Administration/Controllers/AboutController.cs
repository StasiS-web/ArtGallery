using ArtGallery.Core.Models.Administrator;
using ArtGallery.Core.Models.FaqEntity;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Areas.Administration.Controllers
{
    public class AboutController : AdministrationController
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/About/Create")]
        public async Task<IActionResult> Create(FaqCreateInputViewModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return View(model);
            }

            await this.aboutService.CreateAsync(model);
            return this.RedirectToAction("All", "About", new { area = "Administration" });
        }

        public async Task<IActionResult> Edit(int faqId)
        {
            var faqToEdit = await this.aboutService.GetByIdAsync<FaqEditViewModel>(faqId);

            return View(faqToEdit);
        }

        [HttpPost("/About/Edit")]
        public async Task<IActionResult> Edit(FaqEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.aboutService.EditAsync(model);
            return RedirectToAction("All", "About", new { area = "Administration" });
        }

        public async Task<IActionResult> All()
        {
            var faq = await this.aboutService.GetAllFaqsAsync<FaqViewModel>();

            return View(faq);
        }
    }
}
