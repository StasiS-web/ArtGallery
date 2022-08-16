namespace ArtGallery.Tests.Common
{
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.ArtStore;
    using ArtGallery.Core.Models.BlogPosts;
    using ArtGallery.Core.Models.Contacts;
    using ArtGallery.Core.Models.Events;
    using ArtGallery.Core.Models.FaqEntity;
    using ArtGallery.Core.Models.ShoppingCart;
    using ArtGallery.Core.Models.Users;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using constants = ArtGallery.Common.GlobalConstants;

    public static class ObjectGenerator
    {
        public static Event GetEventObject()
        {
            return new Event
            {
                Id = 1,
                Name = "New Event"
            };
        }

        public static EventCreateInputViewModel GetEventCreateInputViewModelObject()
        {
            return new EventCreateInputViewModel
            {
                Name = "New Event",
                Date = DateTime.Now.Date.ToString(constants.Formating.DateTimeFormat),
                Description = "Description",
                Price = 12,
                TicketSelection = TicketType.Free,
                Type = EventType.Online
            };
        }


        public static EventEditViewModel GetEventEditViewModelObject()
        {
            return new EventEditViewModel
            {
                EventId = 1,
                Name = "New Event",
                Date = DateTime.Now.Date.ToString(constants.Formating.DateTimeFormat),
                Description = "Description",
                Price = 12,
                TicketSelection = TicketType.Free,
                Type = EventType.Online
            };
        }


        public static List<ApplicationUser> GetApplicationUserListObject()
        {
            return new List<ApplicationUser>()
                    {
                       new ApplicationUser
                       {
                            Id = Guid.NewGuid().ToString(),
                            UserName = "admin123",
                            FirstName = "Admin",
                            LastName = "LastAdmin"
                        },
                       new ApplicationUser
                       {
                            Id = Guid.NewGuid().ToString(),
                            UserName = "admin223",
                            FirstName = "Admin2",
                            LastName = "LastAdmin2"
                       }
                    };
        }

        public static List<UserViewModel> GetUserViewModelListObject()
        {
            return new List<UserViewModel>()
                    {
                       new UserViewModel
                       {
                            UserId = Guid.NewGuid().ToString(),
                            UserName = "admin123",
                            FirstName = "Admin",
                            LastName = "LastAdmin"
                        },
                       new UserViewModel
                       {
                            UserId = Guid.NewGuid().ToString(),
                            UserName = "admin223",
                            FirstName = "Admin2",
                            LastName = "LastAdmin2"
                       }
                    };
        }

        public static FaqCreateInputViewModel GetFaqCreateInputViewModelObject()
        {
            return new FaqCreateInputViewModel
            {
                Answer = "answer",
                Question = "question"
            };
        }

        public static FaqViewModel GetFaqViewModelObject()
        {
            return new FaqViewModel
            {
                Answer = "answer",
                Question = "question",
                FaqId = 1
            };
        }


        public static FaqEditViewModel GetFaqEditViewModelObject()
        {
            return new FaqEditViewModel
            {
                Answer = "answer",
                Question = "question",
                FaqId = 2
            };
        }

        public static List<FaqViewModel> GetFaqViewModelListObject()
        {
            return new List<FaqViewModel>
            {
               new FaqViewModel
            {
                Answer = "answer",
                Question = "question",
                FaqId=1
            },
               new FaqViewModel
            {
                Answer = "answer",
                Question = "question",
                FaqId=2
            }
        };
        }

        public static ArtOrderViewModel GetArtOrderViewModelObject()
        {
            return new ArtOrderViewModel
            {
                ArtId = 1,
                DeletedOn = DateTime.Now,
                IsDeleted = false,
                OrderDate = DateTime.Now,
                PaintingName = "Art Order",
                Price = 120,
                Quantity = 10,
                Status = 0,
                User = null,
                UserId = "1"
            };
        }

        public static ArtStoreCreateInputModel GetArtStoreCreateInputModelObject()
        {
            return new ArtStoreCreateInputModel
            {
                AuthorName = "Test",
                Description = "Description ",
                PaintingName = "PaintingName",
                Price = 12,
                UrlImage = "test"
            };
        }

        public static ArtStoreViewModel GetArtStoreViewModelObject()
        {
            return new ArtStoreViewModel
            {
                AuthorName = "Test",
                Description = "Description ",
                PaintingName = "PaintingName",
                Price = 12,
                ArtId = 1,
            };
        }

        public static ArtDetailsViewModel GetArtDetailsViewModelObject()
        {
            return new ArtDetailsViewModel
            {
                AuthorName = "Test",
                Description = "Description ",
                PaintingName = "PaintingName",
                Price = 12,
                ArtId = 1,
            };
        }

        public static BlogPostCreateInputModel GetBlogPostCreateInputModelObject()
        {
            return new BlogPostCreateInputModel
            {
                Author = "Test",
                Content = "Content",
                Title = "Title",
                UrlImage = "test",
                UserReaction = ReactionType.Care

            };
        }

        public static BlogPostEditViewModel GetBlogPostEditViewModelObject()
        {
            return new BlogPostEditViewModel
            {
                Content = "Content",
                Title = "Title",
                UrlImage = "test",
            };
        }

        public static BlogPostViewModel GetBlogPostViewModelObject()
        {
            return new BlogPostViewModel
            {
                Content = "Content",
                Title = "Title",
                BlogId = 1,
                Author = "Test",
                CreatedOn = DateTime.Now,
                UrlImageStr = "test",
            };
        }

        public static BlogPost GetBlogPostObject()
        {
            return new BlogPost
            {
                Content = "Content",
                Title = "Title",
                Author = "Test",
                CreatedOn = DateTime.Now,
                Id = 1,
                DeletedOn = DateTime.Now,
                IsDeleted = true,
                ModifiedOn = DateTime.Now,
                UrlImage = "test"
            };
        }

        public static BlogComment GetBlogCommentObject()
        {
            return new BlogComment
            {
                BlogPostId = 1,
                BlogPost = GetBlogPostObject(),
                CommentContent = "CommentContent",
                User = null,
                UserId = "1",
                CreatedOn = DateTime.Now,
                Id = 1,
                DeletedOn = DateTime.Now,
                IsDeleted = true,
                ModifiedOn = DateTime.Now,
            };
        }

        public static BlogCommentViewModel GetBlogCommentViewModelObject()
        {
            return new BlogCommentViewModel
            {
                BlogPost = "BlogPost",
                BlogPostId = "1",
                CommentId = 1,
                CommentContent = "CommentContent",
                User = null,
                UserId = "1",
            };
        }

        public static UserEmailViewModel GetUserEmailViewModelObject()
        {
            return new UserEmailViewModel
            {
                Email = "test@gmail.com",
                Id = 1
            };
        }

        public static ContactFormViewModel GetContactFormViewModelObject()
        {
            return new ContactFormViewModel
            {
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                Message = "test message",
                Subject = "test subject"
            };
        }

        public static SendContactInputViewModel GetSendContactInputViewModelObject()
        {
            return new SendContactInputViewModel
            {
                Email = "test@gmail.com",
                Message = "test message",
                Subject = "test subject",
                FullName = "test",
                UserEmails = new List<UserEmailViewModel> { GetUserEmailViewModelObject() }.AsEnumerable()
            };
        }


        public static EventOrderViewModel GetEventOrderViewModelObject()
        {
            return new EventOrderViewModel
            {
                BookingDate = DateTime.Now,
                BookingId = "1",
                Confirmed = false,
                DeletedOn = DateTime.Now,
                Event = EventType.InPerson,
                EventId = 1,
                IsDeleted = false,
                PaymentMethod = PaymentMethod.GooglePay,
                Price = 12,
                Quantity = 1,
                User = null,
                UserId = "1"
            };
        }

        public static EventOrder GetEventOrderObject()
        {
            return new EventOrder
            {
                BookingDate = DateTime.Now,
                Confirmed = false,
                DeletedOn = DateTime.Now,
                EventId = 1,
                IsDeleted = false,
                PaymentMethod = PaymentMethod.GooglePay,
                Price = 12,
                Quantity = 1,
                User = null,
                UserId = "1",
                Event = GetEventObject(),
            };
        }

        public static ArtGalleryUser GetArtGalleryUserObject()
        {
            return new ArtGalleryUser
            {
                AccessFailedCount = 1,
                BookingsTransactions = new List<BookingTransaction>(),
                Comments = new List<BlogComment> { GetBlogCommentObject() },
                CreatedOn = DateTime.Now,
                DeletedOn = DateTime.Now,
                Email = "test@gmail.com",
                FirstName = "test",
                EmailConfirmed = false,
                Gender = Gender.Male,
                Id = "1",
                LastName = "test",
                LockoutEnabled = false,
                ShoppingCart = new ShoppingCart(),
                ShoppingCartId = 1,
                UserName = "test",
                IsDeleted = false,
            };
        }

        public static ShoppingCartViewModel GetShoppingCartViewModelObject()
        {
            return new ShoppingCartViewModel
            {
                ArtId = 1,
                ArtPrice = 1,
                PaintingName = "test",
                Quantity = 1,
                ShoppingCartId = "1",
                User = null,
                UserId = "1"
            };
        }

    }
}