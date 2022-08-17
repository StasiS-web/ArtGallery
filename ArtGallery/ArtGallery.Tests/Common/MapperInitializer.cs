namespace ArtGallery.Test.Common
{
    using ArtGallery.Core.Mapping;
    using ArtGallery.Core.Models.FaqEntity;
    using ArtGallery.Core.Models.Users;
    using ArtGallery.Infrastructure.Data.Models;
    using System.Reflection;
    public class MapperInitializer
    {
        public void InitializerMapper()
        {
            AutoMapperConfig
            .RegisterMappings(
            typeof(UserViewModel).GetTypeInfo().Assembly,
            typeof(ArtGalleryUser).GetTypeInfo().Assembly);

         
        }
    }
}
