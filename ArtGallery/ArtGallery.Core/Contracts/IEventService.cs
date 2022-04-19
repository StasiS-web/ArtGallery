namespace ArtGallery.Core.Contracts
{
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Events;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEventService
    {
        Task<bool> CreateEventAsync(EventCreateInputViewModel model);

        Task<bool> UpdateEventAsync(EventEditViewModel model);

        void Delete(int id);

        int AllEventsCount();

        IEnumerable<EventViewModel> GetAllEvents(int eventId);

        IEnumerable<int> GetByIdAsync(int eventId);

        Task<IEnumerable<T>> GetUpcomingByIdAsync<T>(int eventId);

        Task AddAsync(EventViewModel model);

        Task<T> GetEventDetailsByIdAsync<T>(int eventId);

        Task<bool> CheckIfEventExists(int eventId);

        Task<bool> CheckAvailableEvents(int eventId, DateTime date);
    }
}
