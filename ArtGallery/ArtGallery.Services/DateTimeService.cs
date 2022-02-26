namespace ArtGallery.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class DateTimeService
    {
        public bool DateValidation(object value)
        {
            string format = "dd-mm-yyyy hh:mm";
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
