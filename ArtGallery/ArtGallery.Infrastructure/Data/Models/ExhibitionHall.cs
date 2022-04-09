namespace ArtGallery.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Infrastructure.Data.Common.Models;
    using ArtGallery.Infrastructure.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.ExhibitionHall;

    public class ExhibitionHall : BaseDeletableModel<int>
    {
        [Required]
        public ExhibitionHallType ExhibitionHallType { get; set; }

        [Range(CapacityMinLength, CapacityMaxLength)]
        public int Capacity { get; set; }
    }
}
