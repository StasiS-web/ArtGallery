namespace ArtGallery.Core.Services
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Events;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using ArtGallery.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static ArtGallery.Common.GlobalConstants.Formating;
    public class EventService : IEventService
    {
        private readonly IAppRepository eventRepo;

        public EventService(IAppRepository eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task<bool> CreateEventAsync(string name, decimal price, string date, 
            string type, string ticketSelection, string description)
        {
            bool isCreated = false;
            var createEvent = new EventCreateInputViewModel();

            if (createEvent != null)
            {
                createEvent.Name = name;
                createEvent.Price = price;
                createEvent.Date = date;
                createEvent.Type = Enum.Parse<EventType>(type);
                createEvent.TicketSelection = Enum.Parse<TicketType>(ticketSelection);
                createEvent.Description = description;

                this.eventRepo.AddAsync(createEvent);
                await this.eventRepo.SaveChangesAsync();
                isCreated = true;
            }

            return isCreated;
        }

        public async Task<bool> UpdateEventAsync(EventEditViewModel model)
        {
            bool isUpdated = false;
            var updateEvent = this.eventRepo.All<Event>()
                                   .FirstOrDefault(e => e.Id == model.EventId);

            if (updateEvent != null)
            {
                updateEvent.Name = model.Name;
                updateEvent.Price = model.Price;
                updateEvent.Date = DateTime.ParseExact(Convert.ToString(model.Date),
                                            NormalDateFormat, CultureInfo.InvariantCulture);
                updateEvent.Type = model.Type;
                updateEvent.TicketSelection = model.TicketSelection;
                updateEvent.Description = model.Description;

                this.eventRepo.Update(updateEvent);
                await this.eventRepo.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
        }

        public void Delete(int id)
        {
            var eventToDelete = this.eventRepo
                         .All<Event>()
                         .Where(e => e.Id == id)
                         .FirstOrDefault();
            this.eventRepo.Delete(eventToDelete);
            this.eventRepo.SaveChangesAsync();
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
                .All<Event>()
                .To<EventViewModel>()
                .OrderByDescending(p => p.EventId == eventId)
                .ToList();
        }

        public async Task AddAsync(EventCreateInputViewModel model)
        {
            await this.eventRepo.AddAsync(new EventViewModel
            {
                Name = model.Name,
                Price = model.Price,
                Date = DateTime.ParseExact(model.Date,
                       DateTimeFormat, CultureInfo.InvariantCulture),
                Description = model.Description,
            });

            await this.eventRepo.SaveChangesAsync();
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
            return await this.eventRepo.All<Event>()
                                 .Where(x => x.Id == eventId &&
                                    x.Date.Date > DateTime.UtcNow.Date)
                                 .OrderBy(x => x.Date)
                                 .To<T>()
                                 .Take(3)
                                 .ToListAsync();
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

        public async Task<bool> CheckAvailableEvents(int eventId, DateTime date)
        {
            return !await this.eventRepo.All<Event>().AnyAsync(e => e.Id == eventId && e.CreatedOn.Date == date.Date);
        }
    }
}
