namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEventsService
    {
        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByEventTypeAsync<T>(string eventId);

        Task<IEnumerable<T>> GetUpcomingByUserAsync<T>(string userId);

        Task<IEnumerable<T>> GetPastByUserByUserIdAsync<T>(string userId);

        Task AddAsync(string userId, string eventName, DateTime dateTime);

        Task DeleteAsync(string id);

        Task ConfirmAsync(string id);

        Task DeclineAsync(string id);
    }
}
