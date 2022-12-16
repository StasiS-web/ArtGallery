namespace ArtGallery.Core.Contracts
{
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Events;
    using ArtGallery.Core.Models.Home;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEventService
    {
        Task CreateEventAsync(EventCreateInputViewModel model);

        Task UpdateEventAsync(EventEditViewModel model);

        void Delete(int id);

        int AllEventsCount();

        IEnumerable<EventViewModel> GetAllEvents(int eventId);

        IEnumerable<int> GetByIdAsync(int eventId);

        Task<IEnumerable<UpcomingEventViewModel>> GetUpcomingByIdAsync<IndexViewModel>(int eventId);

        Task AddAsync(EventCreateInputViewModel model);

        Task<EventViewModel> GetEventDetailsByIdAsync<Event>(int eventId);

        Task<bool> CheckIfEventExists(int eventId);

        Task<bool> CheckAvailableEvents(int eventId, DateTime date);
    }
}
