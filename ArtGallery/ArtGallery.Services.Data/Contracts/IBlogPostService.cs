namespace ArtGallery.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Http;

    public interface IBlogPostService
    {

        IEnumerable<BlogPostViewModel> GetAll();

        int AllBlogsCount();

        IEnumerable<BlogPostViewModel> GetAllBlogs();

        IEnumerable<int> GetById<T>(int id);

        Task AddAsync(BlogPostViewModel model);

        Task<string> GetAuthorIdAsync(int postId);
    }
}
