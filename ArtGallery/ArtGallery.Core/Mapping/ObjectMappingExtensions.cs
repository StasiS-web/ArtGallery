namespace ArtGallery.Core.Mapping
{
    using System;

    public static class ObjectMappingExtensions
    {
        public static T To<T>(this object exist)
        {
            if (exist == null)
            {
                throw new ArgumentNullException(nameof(exist));
            }

            return AutoMapperConfig.MapperInstance.Map<T>(exist);
        }
    }
}
