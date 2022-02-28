﻿namespace ArtGallery.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogPostsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<int>> CountAsync();

        Task<IEnumerable<T>> GetAllWithPagesAsync<T>(int? sortId, int pageSize, int pageIndex);

        Task<int> GetCountForPagesAsync();

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string title, string content, string author, string urlImage, string userReaction);

        Task<IEnumerable<int>> IncreaseViewCountAsync(int blogId);

        Task DeleteAsync(int id);
    }
}
