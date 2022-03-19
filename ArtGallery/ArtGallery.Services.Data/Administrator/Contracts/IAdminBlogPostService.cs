namespace ArtGallery.Services.Data.Administrator.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminBlogPostService
    {
        Task CreateBlogPostAsync(BlogPostCreateInputModel model);

        void Delete(int id);
    }
}
