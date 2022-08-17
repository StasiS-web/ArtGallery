namespace ArtGallery.Controllers
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.BlogPosts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        private readonly IBlogPostService blogPost;

        public BlogController(IBlogPostService blog)
        {
            this.blogPost = blog;
        }

        [Route("/Blog")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? sortId, int blogId)
        {
            if (sortId != null)
            {
                var blogPost = this.blogPost.GetById<BlogPostViewModel>(sortId.Value);

                if (blogPost == null)
                {
                    return new StatusCodeResult(404);
                }
            }

            this.ViewData["CurrentSort"] = sortId;

            var blogPosts = await this.blogPost.GetAll<BlogPostViewModel>(sortId, blogId);
            var blogList = blogPosts.ToList();
           

            // Code changes by bhavin.   
            var allBlogs = blogList.Select(e => new AllBlogPostsListViewModel
            {
                Author = e.Author,
                BlogId = e.BlogId,
                Content = e.Content,
                CreatedOn = e.CreatedOn,
                Title = e.Title,
                UserReaction = e.UserReaction,
                UrlImage=e.UrlImage,

            }).ToList();
            ViewBag.AllBlog = allBlogs;
            return View();
        }

        [Route("/Event/PostDetails/{blogId}")]
        public IActionResult PostDetails(int blogId)
        {
            if (blogId == null)
            {
                return new StatusCodeResult(404);
            }

            var blogPost = this.blogPost.GetBlogPostDetailsByIdAsync<BlogPostViewModel>(blogId);

            return View(blogPost);
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
