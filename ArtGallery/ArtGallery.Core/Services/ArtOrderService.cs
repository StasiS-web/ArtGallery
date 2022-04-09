namespace ArtGallery.Core.Services
{
    using ArtGallery.Core.Models.ArtStore;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using static ArtGallery.Common.MessageConstants;
    using ArtGallery.Infrastructure.Data.Repositories;
    using ArtGallery.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Infrastructure.Data;
    using ArtGallery.Core.Contracts;

    public class ArtOrderService : IArtOrderService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IAppRepository orderRepo;

        public ArtOrderService(IAppRepository orderRepo, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.orderRepo = orderRepo;
        }

        public async Task CreateOrder(ArtOrderViewModel model)
        {
            model.OrderDate = DateTime.UtcNow;
            var user = await orderRepo.All<ArtGalleryUser>()
                                      .FirstOrDefaultAsync(u => u.Id == model.UserId);
            if (user == null)
            {
                throw new ArgumentException(UnknowUser);
            }

            var order = orderRepo.All<ArtOrderViewModel>()
                                 .Where(o => o.Price == model.Price &&
                                          o.Quantity == model.Quantity)
                                 .Include(u => u.UserId == model.UserId)
                                 .FirstOrDefault();

            await this.orderRepo.AddAsync(order);
            await this.orderRepo.SaveChangesAsync();
        }

        public async Task<bool> ReceivedOrder(string artId)
        {
            var orders = this.dbContext.ArtsOrders.Find(artId);

            if (orders == null)
            {
                return false;
            }

            orders.Status = OrderStatus.Received;

            await this.orderRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancleOrder(string artId) // Manager Functionality
        {
            var orders = this.dbContext.ArtsOrders.Find(artId);

            if (orders == null)
            {
                return false;
            }

            orders.Status = OrderStatus.Cancled;

            await this.orderRepo.SaveChangesAsync();

            return true;
        }
    }
}
