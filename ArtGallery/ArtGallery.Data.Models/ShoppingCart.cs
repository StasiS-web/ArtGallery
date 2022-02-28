namespace ArtGallery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Data.Common.Models;

    public class ShoppingCart : BaseModel<int>
    {
        public ShoppingCart()
        {
            this.SaleTransactions = new HashSet<SaleTransaction>();
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
