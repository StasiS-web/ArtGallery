namespace ArtGallery.Infrastructure.Seeding
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;

    internal class InitialDataSeed<T> : IEntityTypeConfiguration<T> where T : class
    {
        private readonly string _filePath;

        public InitialDataSeed(string filePath)
        {
            this._filePath = filePath;
        }
        public void Configure(EntityTypeBuilder<T> builder)
        {
            string? jsonData = GetFromFile();
            
            if (jsonData != null)
            {
                List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonData);

                builder.HasData(data);          
            }
        }

        private string? GetFromFile()
        {
            string? result = null;

            if(File.Exists(_filePath))
            {
                result = File.ReadAllText(_filePath);
            }

            return result;
        }
    }
}
