namespace ArtGallery.Services.Data.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Administrator.Contracts;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.Events;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class AdminEventService : IAdminEventService
    {
        private readonly IAppRepository eventRepo;

        public AdminEventService(IAppRepository eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task CreateEventAsync(EventCreateInputViewModel model)
        {
            await this.eventRepo.AddAsync(new Event
            {
                Name = model.Name,
                Price = model.Price,
                Date = DateTime.ParseExact(
                            Convert.ToString(model.Date),
                            NormalDateFormat,
                            CultureInfo.InvariantCulture),
                Type = model.Type,
                TicketType = model.TicketType,
                Description = model.Description,
            });

            await this.eventRepo.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(EventViewModel model)
        {
            var updateEvent = this.eventRepo.All<Event>()
                                   .FirstOrDefault(e => e.Id == model.EventId);

            updateEvent.Name = model.Name;
            updateEvent.Price = model.Price;
            updateEvent.Date = model.Date;
            updateEvent.Type = model.Type;
            updateEvent.TicketType = model.TicketType;
            updateEvent.Description = model.Description;

            this.eventRepo.Update(updateEvent);
            await this.eventRepo.SaveChangesAsync();
        }

        public async Task ConfirmAsync(int id)
        {
            var eventToConfirm = this.eventRepo
               .All<Event>()
               .Where(e => e.Id == id)
               .FirstOrDefault();

            eventToConfirm.Confirmed = true;
            await this.eventRepo.SaveChangesAsync();
        }

        public async Task DeclineAsync(int id)
        {
            var eventToConfirm = this.eventRepo
               .All<Event>()
               .Where(e => e.Id == id)
               .FirstOrDefault();

            eventToConfirm.Confirmed = false;
            await this.eventRepo.SaveChangesAsync();
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
    }
}
