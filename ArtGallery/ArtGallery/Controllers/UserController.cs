namespace ArtGallery.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ArtGallery.Common;
    using System.Security.Claims;
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.Users;
    using static ArtGallery.Common.GlobalConstants;
    using ArtGallery.Core.Mapping;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly ICloudinaryService cloudinary;

        public UserController(IUserService userService, ICloudinaryService cloudinary)
        {
            this.userService = userService;
            this.cloudinary = cloudinary;
        }

        [HttpGet("/User/Profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var regularUser = await this.userService.GetUser<ProfileViewModel>(userId);

            if (regularUser.UrlImage == null)
            {
                regularUser.UrlImage = Images.DefaultPhoto;
            }

            return View(regularUser);
        }

        [HttpGet("/User/UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(string id)
        {
            var user = await this.userService.GetUser<UserViewModel>(id);

            if (user == null)
            {
                return new StatusCodeResult(404);
            }

            var userProfile = AutoMapperConfig.MapperInstance.Map<ProfileViewModel>(user);

            return View(userProfile);
        }

        [HttpPost("/User/UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userDb = await this.userService.GetUser<ProfileViewModel>(userId);
            var url = this.userService.GetUrl(userDb.UserId);


            string imageUrl = this.cloudinary.UploadImageAsync(model.Photo, Images.DefaultPhoto);
            var userModel = AutoMapperConfig.MapperInstance.Map<ProfileViewModel>(model);

            if (model.UrlImage == null)
            {
                model.UrlImage = url;
            }
            else
            {
                model.UserName = imageUrl;
            }

            var user = this.userService.UpdateProfile(userId, userModel);

            if (user != null)
            {
                this.TempData["MessageConstants"] = MessageConstants.UpdateSuccessMessage;
                return this.Redirect("/User/UpdateProfile");
            }
            else
            {
                this.TempData["MessageConstants"] = MessageConstants.UpdateError;
                return this.RedirectToAction("UpdateProfile");
            }
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    SameSite = SameSiteMode.Strict
                });

            return LocalRedirect(returnUrl);
        }
    }
}
