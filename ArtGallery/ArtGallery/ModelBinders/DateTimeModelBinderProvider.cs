namespace ArtGallery.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string _customDateFormat;

        public DateTimeModelBinderProvider(string _customDateFormat)
        {
            this._customDateFormat = _customDateFormat;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(_customDateFormat);
            }

            return null;
        }
    }
}
