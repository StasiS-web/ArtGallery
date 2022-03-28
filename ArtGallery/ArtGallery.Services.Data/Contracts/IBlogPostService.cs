namespace ArtGallery.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.BlogPosts;

    public interface IBlogPostService
    {
        Task<int> CreateBlogPostAsync(BlogPostCreateInputModel model, string user);

        Task<int> EditBlog(BlogPostEditViewModel model, int blogId);

        void Delete(int id);

        IEnumerable<BlogPostViewModel> GetAll();

        int AllBlogsCount();

        IEnumerable<BlogPostViewModel> GetAllBlogs();

        Task<IEnumerable<T>> GetAll<T>(int? sortId, int blogId);

        IEnumerable<int> GetById<T>(int blogId);

        Task AddAsync(BlogPostViewModel model);

        Task<string> GetAuthorIdAsync(int blogId);

        Task<T> GetBlogPostDetailsByIdAsync<T>(int blogId);

        Task<IEnumerable<BlogPostViewModel>> GetLatestBlogAsync(int blogId);

        Task<bool> BlogPostExists(int blogId);
    }
}
