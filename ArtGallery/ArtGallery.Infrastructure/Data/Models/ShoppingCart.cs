﻿namespace ArtGallery.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ShoppingCart : BaseDeletableModel<int>
    {
        public ShoppingCart()
        {
            this.UserId = Guid.NewGuid().ToString();
            this.Arts = new HashSet<ArtStore>();
        }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(PaintingNameMaxLength)]
        public string PaintingName { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public ICollection<ArtStore> Arts { get; set; }
    }
}
