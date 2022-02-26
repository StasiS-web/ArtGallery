namespace ArtGallery.Services.Data.Contracts
{
    public interface ISettingsService
    {
        int Count();

        IEnumerable<T> GetAll<T>();
    }
}
