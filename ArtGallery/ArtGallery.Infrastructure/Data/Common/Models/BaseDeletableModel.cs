namespace ArtGallery.Infrastructure.Data.Common.Models
{
    using ArtGallery.Data.Common.Models;
    using ArtGallery.Infrastructure.Data.Common.Models.Contracts;
    using System;

    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
