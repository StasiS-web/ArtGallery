namespace ArtGallery.Data.Common.Models.Contarcts
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
