namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task<string> GetBlogIdByCommentsAsync(int commentId);

        Task CreateAsync(int commentId, int blogPostId, string userId, string content);

        Task DeleteAsync(int id);
    }
}
