namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;
    using Microsoft.AspNetCore.Identity;
    using static ArtGallery.Common.GlobalConstants.ArtGalleryUser;

    public class ArtGalleryUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ArtGalleryUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.BlogPosts = new HashSet<BlogPost>();
            this.Comments = new HashSet<BlogComment>();
            this.Events = new HashSet<Event>();
            this.Arts = new HashSet<ArtStore>();
            this.AllSales = new HashSet<SaleTransaction>();
        }

        [Required]
        [MaxLength(UserFullNameMaxLenth)]
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; } // Users are only able to read and comment on Blog Post

        public ICollection<BlogComment> Comments { get; set; }

        public ICollection<Event> Events { get; set; } // Users are only able to book and cancle events 

        public ICollection<ArtStore> Arts { get; set; } // Users are able to buy or cancle orders.Canclation of order need approvements from manager.

        public ICollection<SaleTransaction> AllSales { get; set; }
    }
}
