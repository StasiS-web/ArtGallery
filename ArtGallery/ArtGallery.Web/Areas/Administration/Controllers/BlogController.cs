using ArtGallery.Services.Cloudinary.Contracts;
using ArtGallery.Web.ViewModels.Administrator;
using ArtGallery.Web.ViewModels.BlogPosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class BlogController : AdministrationController
    {
        private readonly IBlogPostService adminService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICloudinaryService cloudinary;

        public BlogController(IBlogPostService adminService, UserManager<ApplicationUser> userManager, ICloudinaryService cloudinary)
        {
            this.adminService = adminService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost("/Blog/CreateBlog")]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> CreateBlog([ModelBinder(typeof(DateTimeModelBinder))] BlogPostCreateInputModel model, string user)
        {
            var userId = this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            string image = this.cloudinary.UploadImageAsync(model.CoverImage, GlobalConstants.CloudMainFolderForImage);
            var blog = Services.Mapping.AutoMapperConfig.MapperInstance.Map<BlogPostCreateInputModel>(model);
            blog.UrlImage = image;
            var blogId = await this.adminService.CreateBlogPostAsync(blog, user);

            this.TempData["MessageConstants"] = MessageConstants.BlogPostCreate;
            return Redirect("/Blog");
        }
    }
}
