namespace ArtGallery.Data.Common.Models
{
    using System;
    using ArtGallery.Data.Common.Models.Contracts;

    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
