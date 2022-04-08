namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.Events;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.MessageConstants;

    public class EventOrderService : IEventOrderService
    {
        private IAppRepository bookingRepo;

        public EventOrderService(IAppRepository bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public async Task CreateOrder(EventOrderViewModel model, bool approved)
        {
            model.BookingDate = DateTime.UtcNow;
            var user = await bookingRepo.All<ArtGalleryUser>()
                                      .FirstOrDefaultAsync(u => u.Id == model.UserId);

            if (user == null)
            {
                throw new ArgumentException(UnknowUser);
            }

            var booking = this.bookingRepo.All<EventOrderViewModel>()
                .Where(b => b.Confirmed == approved && b.UserId == model.UserId && b.BookingDate > DateTime.UtcNow)
                .OrderBy(b => b.BookingDate)
                .To<Event>()
                .ToList();

            await this.bookingRepo.AddAsync(booking);
            await bookingRepo.SaveChangesAsync();
        }

        public async Task ConfirmAsync(int id) // Manager Functionality
        {
            var eventToConfirm = this.bookingRepo
               .All<EventOrder>()
               .Where(e => e.EventId == id)
               .FirstOrDefault();

            eventToConfirm.Confirmed = true;
            await this.bookingRepo.SaveChangesAsync();
        }

        public async Task DeclineAsync(int id) // Manager Functionality
        {
            var eventToConfirm = this.bookingRepo
               .All<EventOrder>()
               .Where(e => e.EventId == id)
               .FirstOrDefault();

            eventToConfirm.Confirmed = false;
            await this.bookingRepo.SaveChangesAsync();
        }
    }
}
