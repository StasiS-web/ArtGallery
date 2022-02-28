namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<int>> CountAsync();

        Task AddAsync(string blogPostId, string userId, string commentContent);

        Task<IEnumerable<int>> IncreaseViewCountAsync(int blogId);

        Task DeleteAsync(int id);
    }
}
