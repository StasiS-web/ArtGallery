namespace ArtGallery.Services.Data.Administrator.Contracts
{
    using ArtGallery.Web.ViewModels.Administrator;

    public interface IAdminBlogPostService
    {
        Task CreateBlogPostAsync(string title, string image, string content, string author);

        void Delete(int id);
    }
}
