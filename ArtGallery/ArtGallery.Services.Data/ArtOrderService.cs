namespace ArtGallery.Services.Data
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Web.ViewModels.ArtStore;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.GlobalConstants.Formating;
    using static ArtGallery.Common.MessageConstants;

    public class ArtOrderService : IArtOrderService
    {
        private readonly IAppRepository orderRepo;

        public ArtOrderService(IAppRepository orderRepo)
        {
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
    }
}
