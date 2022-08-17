using ArtGallery.Core.Models.Administrator;
using ArtGallery.Core.Models.FaqEntity;
using ArtGallery.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Core.Contracts
{
    public interface IAboutService
    {
        Task<FaqViewModel> CreateAsync(FaqCreateInputViewModel model);

        Task EditAsync(FaqEditViewModel model);

        Task DeleteById(int faqId);

        Task<IEnumerable<FaqViewModel>> GetAllFaqsAsync<T>();

        Task<T> GetByIdAsync<T>(int faqId);

    }
}
