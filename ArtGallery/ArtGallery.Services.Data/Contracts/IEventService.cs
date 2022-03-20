namespace ArtGallery.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.Events;

    public interface IEventService
    {
        int AllEventsCount();

        IEnumerable<EventViewModel> GetAllEvents(int eventId);

        IEnumerable<int> GetByIdAsync(int eventId);

        IEnumerable<EventType> GetAllByEventTypeAsync(int eventId, string eventType);

        Task<IEnumerable<T>> GetUpcomingByIdAsync<T>(int eventId);

        Task AddAsync(EventViewModel model);

        Task<T> GetEventDetailsByIdAsync<T>(int eventId);

        Task<bool> CheckIfEventExists(int eventId);
    }
}
