namespace ArtGallery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using ArtGallery.Data.Common.Models;

    public class ShoppingCart : BaseModel<int>
    {
        public ShoppingCart()
        {
            this.SaleTransactions = new HashSet<SaleTransaction>();
        }

        public string UserId { get; set; }

        public ArtGalleryUser User { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
