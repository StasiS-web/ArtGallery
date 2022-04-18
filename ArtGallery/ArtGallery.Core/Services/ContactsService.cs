namespace ArtGallery.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Common;
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Messaging.Contracts;
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Contacts;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class ContactsService : IContactsService
    {
        private readonly IAppRepository contactRepo;
        private readonly IEmailSender emailSender;

        public ContactsService(IAppRepository contactRepo, IEmailSender emailSender)
        {
            this.contactRepo = contactRepo;
            this.emailSender = emailSender;
        }

        public async Task ConatctAdmin(ContactFormViewModel model)
        {
            var contactForm = new ContactForm
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message,
            };

            await this.contactRepo.AddAsync(contactForm);
            await this.contactRepo.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                model.Email,
                string.Concat($"{model.FirstName} {model.LastName}"),
                GlobalConstants.GeneralInfoEmail,
                model.Subject,
                model.Message);
        }

        public async Task ContactUser(SendContactInputViewModel model)
        {
            var adminContactForm = new AdminContactFormViewModel
            {
                FullName = model.FullName,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message,
            };

            await this.contactRepo.AddAsync(adminContactForm);
            await this.contactRepo.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                GlobalConstants.GeneralInfoEmail,
                model.FullName,
                model.Email,
                model.Subject,
                model.Message);
        }

        public async Task<IEnumerable<T>> GetAllUserEmailsAsync<T>()
        {
            var userEmail = await this.contactRepo
                .All<UserEmailViewModel>()
                .To<T>()
                .ToListAsync();

            return userEmail;
        }
    }
}
