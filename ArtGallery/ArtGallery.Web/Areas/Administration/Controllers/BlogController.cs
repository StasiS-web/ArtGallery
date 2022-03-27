using ArtGallery.Services.Data.Administrator.Contracts;
using ArtGallery.Web.ViewModels.Administrator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class BlogController : AdministrationController
    {
        private readonly IAdminBlogPostService adminService;

        public BlogController(IAdminBlogPostService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Blog/CreateBlog")]
        [Authorize]
        public async Task<IActionResult> CreateBlog(BlogPostCreateInputModel model)
        {
            var userId = this.User.FindFirst(model.UrlImage.FileName);

            if (model.UrlImage != null)
            {
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }

    }
}
