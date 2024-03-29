﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Data.Common
{
    public abstract class Repository : IRepository
    {
        protected DbContext dbContext;

        public Repository(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        private DbSet<T> DbSet<T>()
           where T : class
        {
            return this.dbContext.Set<T>();
        }

        public void Add<T>(T entity)
            where T : class
        {
            this.DbSet<T>().Add(entity);
        }

        public async Task AddAsync<T>(T entity)
           where T : class
        {
            await this.DbSet<T>().AddAsync(entity);
        }

        public IQueryable<T> All<T>()
            where T : class
        {
            return this.DbSet<T>().AsQueryable();
        }

        public IQueryable<T> AllReadonly<T>()
            where T : class
        {
            return this.DbSet<T>()
                .AsQueryable()
                .AsNoTracking();
        }

        public async Task DeleteAsync<T>(object id)
            where T : class
        {
            T entity = await this.GetByIdAsync<T>(id);

            Delete<T>(entity);
        }

        public void Delete<T>(T entity)
            where T : class
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.dbContext?.Dispose();
                }
            }

        public async Task<T> GetByIdAsync<T>(object id)
               where T : class
        {
                return await DbSet<T>().FirstAsync((CancellationToken)id);
        }

        public void Update<T>(T entity)
                where T : class
            {
                this.DbSet<T>().Update(entity);
            }

        public void UpdateRange<T>(IEnumerable<T> entities)
            where T : class
        {
            this.DbSet<T>().UpdateRange(entities);
        }

        public IQueryable<T> AllWithDeleted<T>()
            where T : class => this.DbSet<T>().AsQueryable().IgnoreQueryFilters();

        public void HardDelete<T>(T entity)
            where T : class => this.DbSet<T>().Remove(entity);

        public int SaveChanges() => this.dbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}
