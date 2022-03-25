using ArtGallery.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetById(string id)
        {
            var user = userService.GetAllUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
