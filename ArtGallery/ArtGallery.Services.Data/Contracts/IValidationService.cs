namespace ArtGallery.Services.Data.Contracts
{
    public interface IValidationService
    {
        (bool isValid, string error) ValidationModel(object model);
    }
}
