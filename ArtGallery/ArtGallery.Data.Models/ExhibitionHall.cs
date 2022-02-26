namespace ArtGallery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Data.Models.Enumeration;
    using static ArtGallery.Common.GlobalConstants.ExhibitionHall;

    public class ExhibitionHall : BaseDeletableModel<int>
    {
        [Required]
        public ExhibitionHallType ExhibitionHallType { get; set; }

        [Range(CapacityMinLength, CapacityMaxLength)]
        public int Capacity { get; set; }
    }
}
