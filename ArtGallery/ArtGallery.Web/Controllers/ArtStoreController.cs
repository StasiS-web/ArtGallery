using System.Web.Mvc;
using ArtGallery.Services.Data.Administrator.Contracts;
using ArtGallery.Web.ViewModels.Administrator;
using ArtGallery.Web.ViewModels.ArtStore;
using Microsoft.AspNetCore.Mvc;
using static ArtGallery.Common.MessageConstants;

namespace ArtGallery.Web.Controllers
{
    public class ArtStoreController : BaseController
    {
        private readonly IArtStoreService artStoreService;

        public ArtStoreController(IArtStoreService artStoreService)
        {
            this.artStoreService = artStoreService;
        }

        [Authorize]
        public IActionResult Deatails(int artId)
        {
            var artStore = this.artStoreService.Details(artId);

            if (artStore == null)
            {
               throw new ArgumentNullException(InvalidArt);
            }

            return View(artStore);
        }
    }
}
