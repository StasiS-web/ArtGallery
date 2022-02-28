namespace ArtGallery.Services.Data
{
    using System.Collections.Generic;
    using ArtGallery.Data.Common.Repositories;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRespository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRespository)
        {
            this.settingsRespository = settingsRespository;
        }

        public IEnumerable<T> GetAll<T>() => this.settingsRespository.All().To<T>().ToList();

        public int GetCount() => this.settingsRespository.All().Count();
    }
}