namespace ArtGallery.Areas.Administration.Controllers
{
    using ArtGallery.Common;
    using ArtGallery.Controllers;
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Users;
    using ArtGallery.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Security.Claims;

    public class UserController : AdministrationController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/User/ManageUsers")]
        public IActionResult ManageUsers()
        {
            var users = this.userService.GetUsers();

            return View(users);
        }

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
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result,
                }).ToList();

            return View(model);
        }

        [HttpPost("/User/Roles")]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            var user = await userService.GetUserById(model.UserId);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);

            if (model.RoleNames?.Length > 0)
            {
                await userManager.AddToRolesAsync(user, userRoles);
            }

            return RedirectToAction(nameof(ManageUsers));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await userService.GetUserToEdit(id);

            return View(model);
        }

        [HttpPost("/User/Edit")]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await userService.UpdateUser(model))
            {
                ViewData[MessageConstants.OperationalMessage] = "Succefully Written Down";
            }
            else
            {
                ViewData[MessageConstants.OperationalMessage] = "Oops! An error occurred.";
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
