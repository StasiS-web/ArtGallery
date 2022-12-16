using ArtGallery.Core.Models.Administrator;
using ArtGallery.Core.Models.Events;
using ArtGallery.Core.Models.FaqEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FaqEntity = ArtGallery.Infrastructure.Data.Models.FaqEntity;

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

        [HttpPost]
        public async Task<IActionResult> Create(FaqCreateInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            await this.aboutService.CreateAsync(model);
            return this.RedirectToAction("All", "About", new { area = "Administration" });
        }

        [HttpGet("Administration/About/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var faqToEdit = await this.aboutService.GetByIdAsync<FaqEditViewModel>(id);
            var _model = new FaqEditViewModel()
            {
                Question = faqToEdit.Question,
                Answer = faqToEdit.Answer,
            };
            return View(_model);
        }

        [HttpPost("Administration/About/Edit")]
        public async Task<IActionResult> Edit(FaqEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.aboutService.EditAsync(model);
            return RedirectToAction("All", "About", new { area = "Administration" });
        }

        public async Task<IActionResult> All()
        {
            var faq = await this.aboutService.GetAllFaqsAsync<FaqViewModel>();
            ViewBag.faq = faq.ToList();
            return View();
        }

        public async Task<IActionResult> Delete(int faqId)
        {
            this.aboutService.DeleteById(faqId);
            return RedirectToAction(nameof(All));
        }

    }
}
