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
    using static ArtGallery.Common.MessageConstants;

    public class EventOrderService : IEventOrderService
    {
        private IAppRepository bookingRepo;

        public EventOrderService(IAppRepository bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public async Task CreateOrder(EventOrderViewModel model)
        {
            model.BookingDate = DateTime.UtcNow;
            var user = await bookingRepo.All<ArtGalleryUser>()
                                      .FirstOrDefaultAsync(u => u.Id == model.UserId);

            if (user == null)
            {
                throw new ArgumentException(UnknowUser);
            }

            var booking = bookingRepo.All<EventOrderViewModel>()
                                 .Where(o => o.Price == model.Price &&
                                          o.Quantity == model.Quantity)
                                 .Include(u => u.UserId == model.UserId)
                                 .FirstOrDefault();

            await this.bookingRepo.AddAsync(booking);
            await bookingRepo.SaveChangesAsync();
        }
    }
}
