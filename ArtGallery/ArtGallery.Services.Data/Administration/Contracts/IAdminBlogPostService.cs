namespace ArtGallery.Services.Data.Administration.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminBlogPostService
    {
        Task CreateBlogPostAsync(BlogPostCreateInputModel model);

        void Delete(int id);
    }
}
