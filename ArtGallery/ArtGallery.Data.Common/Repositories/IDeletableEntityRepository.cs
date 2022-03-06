namespace ArtGallery.Data.Common.Repositories
{
    using System;
    using System.Collections.Generic;
    using ArtGallery.Data.Common.Models.Contracts;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        IEnumerable<TEntity> All<T>();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
