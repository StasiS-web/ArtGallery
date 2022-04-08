using ArtGallery.Services.Data.Contracts;
using ArtGallery.Web.ViewModels.Administrator;
using ArtGallery.Web.ViewModels.ArtStore;
using Microsoft.AspNetCore.Mvc;
using static ArtGallery.Common.MessageConstants;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class ArtStoreController : AdministrationController
    {
        private readonly IArtStoreService adminService;

        public ArtStoreController(IArtStoreService artService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<IActionResult> CreateArt([ModelBinder(typeof(DecimalModelBinder))] ArtStoreCreateInputModel model)
        {
            var arts = this.adminService.CreateArtAsync(model);

            if (arts == null)
            {
                throw new ArgumentException(nameof(model), NonExistsArt);
            }

            await this.adminService.CreateArtAsync(model);
            return Redirect("/ArtStore/CreateArt");
        }


        public IActionResult EditArtModelBinder(int id)
        {
            var arts = this.adminService.Details(id);

            return View(new ArtStoreCreateInputModel
            {
                PaintingName = arts.PaintingName,
                AuthorName = arts.AuthorName,
                Price = Convert.ToDecimal(arts.Price),
                Description = arts.Description,
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditArt([ModelBinder(typeof(DecimalModelBinder))] ArtStoreViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.adminService.UpdateArtStore(model);
            return Redirect("/ArtStore/EditArt");
        }
    }
}
