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
