using ArtGallery.Services.Data.Administrator.Contracts;
using ArtGallery.Web.ViewModels.Administrator;
using ArtGallery.Web.ViewModels.ArtStore;
using Microsoft.AspNetCore.Mvc;
using static ArtGallery.Common.MessageConstants;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class ArtStoreController : BaseController
    {
        private readonly IArtStoreService artStoreService;
        private readonly IAdminArtStoreService adminArtStore;

        public ArtStoreController(IArtStoreService artStoreService, IAdminArtStoreService adminArtStore)
        {
            this.artStoreService = artStoreService;
            this.adminArtStore = adminArtStore;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        private async Task<IActionResult> CreateAsync(ArtStoreCreateInputModel model)
        {
            var arts = adminArtStore.CreateArtAsync(model);

            if (arts == null)
            {
                throw new ArgumentException(nameof(model), ArtExists);
            }

            await this.adminArtStore.CreateArtAsync(model);
            return Redirect("/Views/ArtStore");
        }

        [HttpGet]
        public IActionResult EditAsync(int id)
        {
            var arts = this.artStoreService.Details(id);

            return View(new ArtStoreCreateInputModel
            {
                PaintingName = arts.PaintingName,
                AuthorName = arts.AuthorName,
                UrlImage = arts.UrlImage,
                Price = (decimal)arts.Price,
                Description = arts.Description,
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(ArtStoreViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.adminArtStore.UpdateArtStore(model);
            return Redirect("/View/ArtStore");
        }
    }
}
