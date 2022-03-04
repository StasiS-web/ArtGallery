namespace ArtGallery.Services
{
    using System;
    using System.Globalization;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class DateTimeService
    {
        public bool DateValidation(object value)
        {
            string format = DateTimeFormate;
            var isValid = DateTime.TryParseExact(
                Convert.ToString(value),
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dateTime);

            return isValid;
        }
    }
}
