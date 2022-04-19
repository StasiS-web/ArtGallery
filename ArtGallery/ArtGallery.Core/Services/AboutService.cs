namespace ArtGallery.Core.Services
{
    using ArtGallery.Common;
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.FaqEntity;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FaqEntity = Infrastructure.Data.Models.FaqEntity;

    public class AboutService : IAboutService
    {
        private readonly IAppRepository faqRepo;

        public AboutService(IAppRepository faqRepo)
        {
            this.faqRepo = faqRepo;
        }

        public async Task<FaqViewModel> CreateAsync(FaqCreateInputViewModel model)
        {
            var faq = new FaqViewModel
            { 
                Question = model.Question,
                Answer = model.Answer,
            };

            bool isExist = await faqRepo.All<FaqViewModel>()
                .AnyAsync(x => x.Question == model.Question && x.Answer == model.Answer);

           if(isExist)
           {
                throw new ArgumentException(string.Format(MessageConstants.FaqAlreadyExist, model.Question, model.Answer));
           }

           await faqRepo.AddAsync(faq);
           await faqRepo.SaveChangesAsync();

           var viewModel = await this.GetByIdAsync<FaqViewModel>(faq.FaqId);

           return viewModel;
        }

        public async Task DeleteById(int faqId)
        {
            var faq = faqRepo.All<FaqEntity>().FirstOrDefault(x => x.Id == faqId);

            if (faq == null)
            {
                throw new ArgumentNullException(string.Format(MessageConstants.FaqNotFound, faqId));
            }

            faq.IsDeleted = true;
            faq.DeletedOn = DateTime.UtcNow;
            faqRepo.Update(faq);
            faqRepo.SaveChanges();
        }

        public async Task EditAsync(FaqEditViewModel model)
        {
            var faq = faqRepo.All<FaqEntity>().FirstOrDefault(x => x.Id == model.FaqId);

            if (faq == null)
            {
                throw new ArgumentNullException(string.Format(MessageConstants.FaqNotFound, model.FaqId));
            }

            faq.Answer = model.Answer;
            faq.Question = model.Question;
            faq.ModifiedOn = DateTime.UtcNow;

            faqRepo.Update(faq);
            faqRepo.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllFaqsAsync<T>()
        {
            var allFaq = this.faqRepo.All<FaqViewModel>()
                .To<T>()
                .ToList();

            return allFaq;
        }

        public async Task<T> GetByIdAsync<T>(int faqId)
        {
            var faqModel = faqRepo
                .All<FaqViewModel>()
                .Where(f => f.FaqId == faqId)
                .To<T>()
                .FirstOrDefault();

            return faqModel;
        }
    }
}
