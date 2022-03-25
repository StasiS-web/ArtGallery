using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogPostService blogPost;

        public BlogController(IBlogPostService blog)
        {
            this.blogPost = blog;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok();
        }

        [HttpGet("{blogId}")]
        public IActionResult GetOnce([FromRoute] int blogId)
        {
            return Ok();
        }
    }
}
