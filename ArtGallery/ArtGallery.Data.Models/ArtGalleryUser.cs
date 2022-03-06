namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Common.Models.Contracts;
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

            this.Comments = new HashSet<BlogComment>();
            this.SaleTransaction = new HashSet<SaleTransaction>();
            this.BookingsTransactions = new HashSet<BookingTransaction>();
        }

        [Required]
        [MaxLength(FullNameMinLenth)]
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string UrlImage { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public ICollection<BlogComment> Comments { get; set; }

        public ICollection<SaleTransaction> SaleTransaction { get; set; }

        public ICollection<BookingTransaction> BookingsTransactions { get; set; }
    }
}
