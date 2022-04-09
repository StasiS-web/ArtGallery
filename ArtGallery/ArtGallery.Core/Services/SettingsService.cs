namespace ArtGallery.Core.Services
{
    using System.Collections.Generic;
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Mapping;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;
    public class SettingsService : ISettingsService
    {
        private readonly IAppRepository settingsRespository;

        public SettingsService(IAppRepository settingsRespository)
        {
            this.settingsRespository = settingsRespository;
        }

        public IEnumerable<T> GetAll<T>() => this.settingsRespository.All<Setting>().To<T>().ToList();

        public int GetCount() => this.settingsRespository.All<Setting>().Count();
    }
}