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
        private readonly IAppRepository _contactRepo;
        private readonly IEmailSender _emailSender;

        public ContactsService(IAppRepository contactRepo, IEmailSender emailSender)
        {
            this._contactRepo = contactRepo;
            this._emailSender = emailSender;
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

            await this._contactRepo.AddAsync(contactForm);
            await this._contactRepo.SaveChangesAsync();

            await this._emailSender.SendEmailAsync(
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

            await this._contactRepo.AddAsync(adminContactForm);
            await this._contactRepo.SaveChangesAsync();

            await this._emailSender.SendEmailAsync(
                GlobalConstants.GeneralInfoEmail,
                model.FullName,
                model.Email,
                model.Subject,
                model.Message);
        }

        public async Task<IEnumerable<T>> GetAllUserEmailsAsync<T>()
        {
            var userEmail = await this._contactRepo
                .All<UserEmailViewModel>()
                .To<T>()
                .ToListAsync();

            return userEmail;
        }
    }
}
