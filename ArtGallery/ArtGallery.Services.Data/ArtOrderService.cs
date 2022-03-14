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

    public class ArtOrderService : IArtOrderService
    {
        private IAppRepository orderRepo;

        public ArtOrderService(IAppRepository order)
        {
             this.orderRepo = order;
        }

        public async Task CreateOrder(ArtOrderViewModel model)
        {
            var order = orderRepo.All<ArtOrderViewModel>()
                         .Where(x => x.UserId == model.UserId)
                         .Where(x => x.ArtId == model.ArtId)
                         .Include(o => o.Price == model.Price &&
                                  o.Quantity == model.Quantity);

            await this.orderRepo.AddAsync(order);
            await this.orderRepo.SaveChangesAsync();
        }
    }
}
