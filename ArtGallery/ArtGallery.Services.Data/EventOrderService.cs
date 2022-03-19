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
    using ArtGallery.Web.ViewModels.Events;
    using Microsoft.EntityFrameworkCore;

    public class EventOrderService : IEventOrderService
    {
        private IAppRepository bookingRepo;

        public EventOrderService(IAppRepository bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public async Task CreateOrder(EventOrderViewModel model)
        {
            var booking = bookingRepo.All<EventOrder>()
                                     .Where(x => x.UserId == model.UserId)
                                     .Where(x => x.EventId == model.EventId)
                                     .Include(b => b.Price == model.Price &&
                                                  b.Quantity == model.Quantity);

            await this.bookingRepo.AddAsync(booking);
            await bookingRepo.SaveChangesAsync();
        }
    }
}
