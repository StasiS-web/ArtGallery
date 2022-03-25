using ArtGallery.Web.ViewModels.Administrator;
using ArtGallery.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ArtGalleryUser> userManager;
        private readonly IUserService userService;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ArtGalleryUser> userManager, IUserService userService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            var users = this.userService.GetUsers();

            return View(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Roles(string userId)
        {
            var user = await userService.GetUserById(userId);
            var model = new UserRolesViewModel()
            {
                UserId = userId,
                Name = $"{user.FirstName} {user.LastName}"
            };

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Id,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await userService.GetUserToEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await userService.UpdateUser(model))
            {
                ViewData[MessageConstants.OperationalMessages] = "Succefully Written Down";
            }
            else
            {
                ViewData[MessageConstants.OperationalMessages] = "Oops! An error occurred.";
            }

            return View(model);
        }

        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "ArtGallery"
            });

            return Ok();
        }
    }
}
