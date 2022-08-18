namespace ArtGallery.Core.Services
{
    using System.Collections.Generic;
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;
    public class SettingsService : ISettingsService
    {
        private readonly IAppRepository _settingsRespository;

        public SettingsService(IAppRepository settingsRespository)
        {
            this._settingsRespository = settingsRespository;
        }

        public IEnumerable<T> GetAll<T>() => this._settingsRespository.All<Setting>().To<T>().ToList();

        public int GetCount() => this._settingsRespository.All<Setting>().Count();
    }
}