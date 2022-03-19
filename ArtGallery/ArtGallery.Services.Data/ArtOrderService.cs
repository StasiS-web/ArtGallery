namespace ArtGallery.Services.Data
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.ArtStore;
    using ArtGallery.Web.ViewModels.Users;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.GlobalConstants.Formating;
    using static ArtGallery.Common.MessageConstants;

    public class ArtOrderService : IArtOrderService
    {
        private readonly IAppRepository orderRepo;

        public ArtOrderService(IAppRepository order)
        {
             this.orderRepo = order;
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
    }
}
