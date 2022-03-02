namespace ArtGallery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Common.Models.Contarcts;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        // Audit info
        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}