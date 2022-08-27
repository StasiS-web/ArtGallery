using System.Collections.Immutable;
using CloudinaryDotNet.Actions;

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
    using System.Linq;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Authorization;

    // Code changes by behaviour.
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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

         public async Task<IActionResult> Index()
         {
             var allUsers = await userManager.Users.ToListAsync();
             var userRolesViewModel = new List<UserRolesViewModel>();

             foreach (ApplicationUser user in allUsers)
             {
                 var viewModel = new UserRolesViewModel();
                 viewModel.UserId = user.Id;
                 viewModel.Name = $"{user.FirstName} {user.LastName}";
                 viewModel.UserName = user.UserName;
                 viewModel.Email = user.Email;
                 viewModel.RoleNames = ViewBag.RoleNames;
                 userRolesViewModel.Add(viewModel);
             }

             ViewBag.userRolesViewModel = userRolesViewModel.ToList();
             return View();
         }
        

        [HttpGet("Administration/User/ManageUsers")]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await this.userService.GetUsers();
            var manageUsers = users.Select(x => new UserListViewModel()
            {
                Email = x.Email,
                UserName = x.UserName,
                Id = x.Id,
                Name = x.Name,
            });
            ViewBag.manageUsers = manageUsers.ToList();
            return View();
        }


        public async Task<IActionResult> Roles(string id)
        {
            var user = await userService.GetUserById(id);
            var model = new UserRolesViewModel()
            {
                UserId = id,
                Name = $"{user.FirstName} {user.LastName}"
            };

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Id,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result,
                })
                .ToList();

            return View(model);
        }

       

        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            var user = await userService.GetUserById(model.UserId);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);

            if (model.RoleNames?.Count() > 0)
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

        [HttpPost]
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
                Name = "Admin"
            });

            return Ok();
        }
    }
}