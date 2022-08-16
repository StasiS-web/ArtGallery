namespace ArtGallery.Core.Services
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Events;
    using ArtGallery.Core.Models.Home;
    using ArtGallery.Infrastructure.Data;
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
        private readonly IAppRepository _eventRepo;
        private readonly ApplicationDbContext _applicationDbContext;

        public EventService(IAppRepository eventRepo, ApplicationDbContext applicationDbContext)
        {
            this._eventRepo = eventRepo;
            this._applicationDbContext = applicationDbContext;
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

                //this.eventRepo.AddAsync(createEvent);
                //await this.eventRepo.SaveChangesAsync();

                _applicationDbContext.Events.Add(new Event()
                {
                    Name = name,
                    Price = price,
                    Date = Convert.ToDateTime(date),
                    Type = Enum.Parse<EventType>(type),
                    TicketSelection = Enum.Parse<TicketType>(ticketSelection),
                    Description = description,
                    CreatedOn = DateTime.UtcNow,

                });

                _applicationDbContext.SaveChanges();

            }

            return isCreated;
        }

        public async Task<bool> UpdateEventAsync(EventEditViewModel model)
        {
            bool isUpdated = false;
            //var updateEvent = this.eventRepo.All<Event>()
            //                       .FirstOrDefault(e => e.Id == model.EventId);
            var updateEvent = _applicationDbContext.Events
                             .FirstOrDefault(e => e.Id == model.EventId);

            if (updateEvent != null)
            {
                updateEvent.Name = model.Name;
                updateEvent.Price = model.Price;
                //updateEvent.Date = DateTime.ParseExact(Convert.ToString(model.Date),
                //                            NormalDateFormat, CultureInfo.InvariantCulture);
                updateEvent.Date = DateTime.Parse(model.Date);
                updateEvent.Type = model.Type;
                updateEvent.TicketSelection = model.TicketSelection;
                updateEvent.Description = model.Description;

                //this.eventRepo.Update(updateEvent);
                //await this.eventRepo.SaveChangesAsync();
                _applicationDbContext.Events.Update(updateEvent);
                _applicationDbContext.SaveChanges();
                isUpdated = true;
            }

            return isUpdated;
        }

        public void Delete(int id)
        {
            //var eventToDelete = this.eventRepo
            //             .All<Event>()
            //             .Where(e => e.Id == id)
            //             .FirstOrDefault();

            var eventToDelete = _applicationDbContext.Events
                        .FirstOrDefault(e => e.Id == id);

            //this.eventRepo.Delete(eventToDelete);
            //this.eventRepo.SaveChangesAsync();
            _applicationDbContext.Events.Remove(eventToDelete);
            _applicationDbContext.SaveChanges();
        }

        public int AllEventsCount()
        {
            //return this.eventRepo
            //       .All<Event>()
            //       .Count();

            return _applicationDbContext.Events
                  .Count();
        }

        public IEnumerable<EventViewModel> GetAllEvents(int eventId)
        {
            //return this.eventRepo
            //    .All<Event>()
            //    .To<EventViewModel>()
            //    .OrderByDescending(p => p.EventId == eventId)
            //    .ToList();

            // Code changes by bhavin.   
            return _applicationDbContext.Events.Select(x => new EventViewModel
            {
                EventId = x.Id,
                Name = x.Name,
                Date = x.Date,
                Price = x.Price,
                Description = x.Description,
                TicketSelection = x.TicketSelection,
                Type = x.Type
            }).OrderByDescending(p => p.EventId == eventId).ToList();
        }

        public async Task AddAsync(EventCreateInputViewModel model)
        {
            //await this.eventRepo.AddAsync(new EventViewModel
            //{
            //    Name = model.Name,
            //    Price = model.Price,
            //    Date = DateTime.ParseExact(model.Date,
            //           DateTimeFormat, CultureInfo.InvariantCulture),
            //    Description = model.Description,
            //});

            await _applicationDbContext.Events.AddAsync(new Event
            {
                Name = model.Name,
                Price = model.Price,
                Date = DateTime.ParseExact(model.Date,
                      DateTimeFormat, CultureInfo.InvariantCulture),
                Description = model.Description,
            });

            // await this.eventRepo.SaveChangesAsync();
            await _applicationDbContext.SaveChangesAsync();
        }

        public IEnumerable<int> GetByIdAsync(int eventId)
        {
            //var events = this.eventRepo
            //        .All<EventViewModel>()
            //        .Where(x => x.EventId == eventId)
            //        .FirstOrDefault();

            var events = _applicationDbContext.Events
                   .FirstOrDefault(x => x.Id == eventId);

            return (IEnumerable<int>)events;
        }

        public async Task<IEnumerable<UpcomingEventViewModel>> GetUpcomingByIdAsync<T>(int eventId)
        {
            // Code changes by bhavin.   
            //return await this.eventRepo.All<Event>()
            //                     .Where(x => x.Id == eventId &&
            //                        x.Date.Date > DateTime.UtcNow.Date)
            //                     .OrderBy(x => x.Date)
            //                     .To<T>()
            //                     .Take(3)
            //                     .ToListAsync();

            return await _applicationDbContext.Events
                // .Where(x => x.Id == eventId && x.Date.Date > DateTime.UtcNow.Date)
                .Where(x => x.Date.Date > DateTime.UtcNow.Date)
                .Select(x => new UpcomingEventViewModel
                {
                    Date = x.Date.ToString(),
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    Type = x.Type,
                })
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToListAsync();

        }

        public async Task<EventViewModel> GetEventDetailsByIdAsync<T>(int eventId)
        {
            //var eventDetails = this.eventRepo
            //                .All<EventViewModel>()
            //                .Where(e => e.EventId == eventId)
            //                .To<T>()
            //                .FirstOrDefault();

            var eventDetails = _applicationDbContext.Events
                            .Where(x => x.Id == eventId)
                            .Select(x => new EventViewModel()
                            {
                                EventId = eventId,
                                Name = x.Name,
                                Date = x.Date,
                                Price = x.Price,
                                Description = x.Description,
                                TicketSelection = x.TicketSelection,
                                Type = x.Type
                            }).FirstOrDefault();


            return eventDetails;
        }

        public async Task<bool> CheckIfEventExists(int eventId)
        {
            //var even = await this.eventRepo
            //            .All<EventViewModel>()
            //            .FirstOrDefaultAsync(x => x.EventId == eventId);

            var even = await _applicationDbContext.Events
                       .FirstOrDefaultAsync(x => x.Id == eventId);

            return even != null;
        }

        public async Task<bool> CheckAvailableEvents(int eventId, DateTime date)
        {
            // return !await this.eventRepo.All<Event>().AnyAsync(e => e.Id == eventId && e.CreatedOn.Date == date.Date);
            return !await _applicationDbContext.Events.Where(e => e.Id == eventId && e.CreatedOn.Date == date.Date).AnyAsync();
        }
    }
}