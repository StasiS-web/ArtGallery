namespace ArtGallery.Services.Data.Contracts
{
    public interface ISettingsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
