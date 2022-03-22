namespace ArtGallery.Services.Data.Administrator
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

        public async Task<bool> CreateEventAsync(EventCreateInputViewModel model)
        {
            bool isCreated = false;
            var createEvent = new Event();

            if (createEvent != null)
            {
                createEvent.Name = model.Name;
                createEvent.Price = model.Price;
                createEvent.Date = DateTime.Parse(
                                 Convert.ToString(model.Date),
                                 CultureInfo.InvariantCulture);
                createEvent.Type = model.Type;
                createEvent.TicketType = model.TicketType;
                createEvent.Description = model.Description;

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
                updateEvent.Date = DateTime.Parse(
                                    Convert.ToString(model.Date),
                                    CultureInfo.InvariantCulture);
                updateEvent.Type = model.Type;
                updateEvent.TicketType = model.TicketType;
                updateEvent.Description = model.Description;

                this.eventRepo.Update(updateEvent);
                await this.eventRepo.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
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

