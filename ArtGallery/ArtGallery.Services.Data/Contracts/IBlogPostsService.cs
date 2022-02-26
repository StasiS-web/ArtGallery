namespace ArtGallery.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogPostsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<IEnumerable<T>> GetAllWithPagesAsync<T>(int? sortId, int pageSize, int pageIndex);

        Task<int> GetCountForPagesAsync();

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string title, string content, string author, string userReaction);

        Task DeleteAsync(int id);
    }
}
