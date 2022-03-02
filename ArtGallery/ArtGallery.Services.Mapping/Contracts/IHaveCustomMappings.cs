namespace ArtGallery.Services.Mapping.Contracts
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
