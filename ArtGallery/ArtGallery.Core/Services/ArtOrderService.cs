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

    public class ArtOrder : IArtOrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAppRepository _orderRepo;

        public ArtOrder(IAppRepository orderRepo, ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._orderRepo = orderRepo;
        }

        public async Task CreateOrder(ArtOrderViewModel model)
        {
            model.OrderDate = DateTime.UtcNow;
            var user = await _orderRepo.All<ArtGalleryUser>()
                                      .FirstOrDefaultAsync(u => u.Id == model.UserId);
            if (user == null)
            {
                throw new ArgumentException(UnknowUser);
            }

            var order = _orderRepo.All<ArtOrderViewModel>()
                                 .Where(o => o.Price == model.Price &&
                                          o.Quantity == model.Quantity)
                                 .Include(u => u.UserId == model.UserId)
                                 .FirstOrDefault();

            await this._orderRepo.AddAsync(order);
            await this._orderRepo.SaveChangesAsync();
        }

        public async Task<bool> ReceivedOrder(string artId)
        {
            var orders = this._dbContext.ArtsOrders.Find(artId);

            if (orders == null)
            {
                return false;
            }

            orders.Status = OrderStatus.Received;

            await this._orderRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancleOrder(string artId) // Manager Functionality
        {
            var orders = this._dbContext.ArtsOrders.Find(artId);

            if (orders == null)
            {
                return false;
            }

            orders.Status = OrderStatus.Cancled;

            await this._orderRepo.SaveChangesAsync();

            return true;
        }
    }
}
