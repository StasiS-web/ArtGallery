namespace ArtGallery.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Web.ViewModels.BlogPosts;

    public interface IBlogPostService
    {

        IEnumerable<BlogPostViewModel> GetAll();

        int AllBlogsCount();

        IEnumerable<BlogPostViewModel> GetAllBlogs();

        Task<IEnumerable<T>> GetAll<T>(int? sortId, int blogId);

        IEnumerable<int> GetById<T>(int blogId);

        Task AddAsync(BlogPostViewModel model);

        Task<string> GetAuthorIdAsync(int blogId);

        Task<T> GetBlogPostDetailsByIdAsync<T>(int blogId);

        Task<IEnumerable<BlogPostViewModel>> GetLatestBlogAsync(int blogId);
    }
}
