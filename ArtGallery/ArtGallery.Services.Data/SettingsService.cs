namespace ArtGallery.Services.Data
{
    using System.Collections.Generic;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;

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