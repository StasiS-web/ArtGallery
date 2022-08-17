namespace ArtGallery.Core.Contracts
{
    public interface ICommentsService
    {
        Task<string> GetBlogIdByCommentsAsync(int commentId);

        Task CreateAsync(int commentId, int blogPostId, string userId, string content);

        Task DeleteAsync(int id);
    }
}
