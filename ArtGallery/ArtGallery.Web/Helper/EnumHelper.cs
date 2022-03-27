namespace ArtGallery.Web.Helper
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

    public static class EnumHelper
    {
       public static string GetDescription<TEnum>(this TEnum value)
       {
            var field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
       }

       public static SelectList SelectListItemsFor<T>(T selected)
            where T : struct
       {
            Type t = typeof(T);
            return !t.IsEnum ? null : new SelectList(BuildSelectListItem(t), "Value", "Text", selected.ToString());
       }

       private static IEnumerable<SelectListItem> BuildSelectListItem(Type t)
       {
            return Enum.GetValues(t)
                .Cast<Enum>()
                .Select(e => new SelectListItem { Value = e.ToString(), Text = e.GetDescription() });
       }
    }
}
