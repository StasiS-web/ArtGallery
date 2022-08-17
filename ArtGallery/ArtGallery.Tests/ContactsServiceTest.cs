using ArtGallery.Core.Contracts;
using ArtGallery.Core.Messaging.Contracts;
using ArtGallery.Core.Models.Contacts;
using ArtGallery.Core.Services;
using ArtGallery.Infrastructure.Data;
using ArtGallery.Infrastructure.Data.Repositories;
using ArtGallery.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Tests
{
    public class ContactsServiceTest
    {
        private Mock<IAppRepository> _repo;
        private Mock<IContactsService> _contactsService;
        private Mock<IEmailSender> _emailSender;
        private ApplicationDbContext _context;
        public ContactsServiceTest()
        {
            _repo = new Mock<IAppRepository>();
            _contactsService = new Mock<IContactsService>();
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "ContactsDb")
         .Options);
            _emailSender = new Mock<IEmailSender>();
        }

        [Fact]
        public void GetAllUserEmailsAsync_Test()
        {
            // Assert
            _repo.Setup(x => x.All<UserEmailViewModel>()).Returns(new List<UserEmailViewModel>
            {
            }.AsQueryable());
            _contactsService.Setup(x => x.GetAllUserEmailsAsync<UserEmailViewModel>()).Returns(Task.Run(() => new List<UserEmailViewModel>
            {
            }.AsEnumerable()));

            // Act
            var service = new ContactsService(_repo.Object, _emailSender.Object);

            // Verify
            _contactsService.Verify(x => x.GetAllUserEmailsAsync<UserEmailViewModel>(), Times.Never);
        }

        [Fact]
        public void ConatctAdmin_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync<ContactFormViewModel>(ObjectGenerator.GetContactFormViewModelObject()));
            _contactsService.Setup(x => x.ConatctAdmin(ObjectGenerator.GetContactFormViewModelObject()));

            // Act
            var service = new ContactsService(_repo.Object, _emailSender.Object);

            // Verify
            _contactsService.Verify(x => x.ConatctAdmin(ObjectGenerator.GetContactFormViewModelObject()), Times.Never);
        }

        [Fact]
        public void ContactUser_Test()
        {
            // Assert
            _repo.Setup(x => x.AddAsync<SendContactInputViewModel>(ObjectGenerator.GetSendContactInputViewModelObject()));
            _contactsService.Setup(x => x.ContactUser(ObjectGenerator.GetSendContactInputViewModelObject()));

            // Act
            var service = new ContactsService(_repo.Object, _emailSender.Object);

            // Verify
            _contactsService.Verify(x => x.ContactUser(ObjectGenerator.GetSendContactInputViewModelObject()), Times.Never);
        }
    }
}
