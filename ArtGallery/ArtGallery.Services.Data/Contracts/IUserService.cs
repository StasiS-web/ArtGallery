namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<IEnumerable<T>> GetUserAsync<T>(string userId);

        Task AddAsync(string fullName);

        Task DeleteAsync(int userId);
    }
}
