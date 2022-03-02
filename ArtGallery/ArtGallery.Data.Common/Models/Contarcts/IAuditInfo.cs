namespace ArtGallery.Data.Common.Models.Contarcts
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
