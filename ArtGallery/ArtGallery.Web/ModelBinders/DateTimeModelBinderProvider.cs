﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ArtGallery.Web.ModelBinders
{

    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string customDateFormat;

        public DateTimeModelBinderProvider(string _customDateFormat)
        {
            this.customDateFormat = _customDateFormat;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(customDateFormat);
            }

            return null;
        }
    }
}
