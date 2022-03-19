﻿namespace ArtGallery.Services.Data.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Administration.Contracts;
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

        public Task ConfirmAsync(int id)
        {
            var eventByType = this.eventRepo
               .All<EventViewModel>()
               .Where(e => e.EventId == id)
               .FirstOrDefault();

            throw new NotImplementedException();
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
