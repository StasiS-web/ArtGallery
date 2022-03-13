namespace ArtGallery.Services.Data
{
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.ArtStore;
    using ArtGallery.Web.ViewModels.Users;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
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
            var order = new ArtOrder
            {
                OrderDate = DateTime.ParseExact(
                        Convert.ToString(model.OrderDate),
                        NormalDateFormat,
                        CultureInfo.InvariantCulture),
                UserId = model.UserId,
                ArtId = model.ArtId,
                Quantity = model.Quantity,
                Price = model.Price,
            };

            await this.orderRepo.AddAsync(order);
            await this.orderRepo.SaveChangesAsync();
        }
    }
}
