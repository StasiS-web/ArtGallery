﻿namespace ArtGallery.Test.Common
{
    using ArtGallery.Infrastructure.Data;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class InMemoryDbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<ApplicationDbContext> contextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory");
            connection.Open();

            contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connection)
                .Options;
            using var context = new ApplicationDbContext(contextOptions);
            context.Database.EnsureCreated();
        }

        public ApplicationDbContext CreateContext() => new ApplicationDbContext(contextOptions);

        public static ApplicationDbContext InitilializeContext()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(option);
        }

        public void Dispose() => connection.Dispose();

        public static implicit operator InMemoryDbContext(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}
