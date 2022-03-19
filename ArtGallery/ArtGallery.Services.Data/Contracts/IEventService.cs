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

        IEnumerable<int> GetByIdAsync(int id);

        IEnumerable<EventType> GetAllByEventTypeAsync(int eventId, string eventType);

        IEnumerable<int> GetUpcomingByIdAsync(int id);

        Task AddAsync(EventViewModel model);
    }
}
