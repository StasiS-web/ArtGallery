namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.Events;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class EventService : IEventService
    {
        private readonly IAppRepository eventRepo;

        public EventService(IAppRepository eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public int AllEventsCount()
        {
            return this.eventRepo
                   .All<Event>()
                   .Count();
        }

        public IEnumerable<EventViewModel> GetAllEvents(int eventId)
        {
            return this.eventRepo
                .All<EventViewModel>()
                .Where(u => u.EventId == eventId)
                .ToList();
        }

        public async Task AddAsync(EventViewModel model)
        {
            await this.eventRepo.AddAsync(new Event
            {
                Name = model.Name,
                Price = model.Price,
                Date = DateTime.ParseExact(
                            Convert.ToString(model.Date),
                            NormalDateFormat,
                            CultureInfo.InvariantCulture),
                Description = model.Description,
            });

            await this.eventRepo.SaveChangesAsync();
        }

        public IEnumerable<EventType> GetAllByEventTypeAsync(int eventId, string eventType)
        {
            var eventByType = this.eventRepo
                .All < EventViewModel>()
                .Where(e => e.EventId == eventId)
                .Where(e => e.Type == eventType)
                .FirstOrDefault();

            return (IEnumerable<EventType>)eventByType;
        }

        public IEnumerable<int> GetByIdAsync(int eventId)
        {
            var events = this.eventRepo
                    .All<EventViewModel>()
                    .Where(x => x.EventId == eventId)
                    .FirstOrDefault();

            return (IEnumerable<int>)events;
        }

        public async Task<IEnumerable<T>> GetUpcomingByIdAsync<T>(int eventId)
        {
            var upcomingEvents = this.eventRepo
                                 .All<EventViewModel>()
                                 .Where(x => x.EventId == eventId &&
                                    x.Date.Date > DateTime.UtcNow.Date)
                                 .OrderBy(x => x.Date)
                                 .To<T>().ToListAsync();

            return await upcomingEvents;
        }

        public async Task<T> GetEventDetailsByIdAsync<T>(int eventId)
        {
            var eventDetails = this.eventRepo
                            .All<EventViewModel>()
                            .Where(e => e.EventId == eventId)
                            .To<T>()
                            .FirstOrDefault();

            return eventDetails;
        }

        public async Task<bool> CheckIfEventExists(int eventId)
        {
            var even = await this.eventRepo
                        .All<EventViewModel>()
                        .FirstOrDefaultAsync(x => x.EventId == eventId);

            return even != null;
        }
    }
}
