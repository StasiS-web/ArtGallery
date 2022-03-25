namespace ArtGallery.Web.ViewModels.Administrator
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    public class ActionTypeModel
    {
        public ActionTypeModel()
        {

        }

        [Display(Name = "Action")]
        public int ActionId { get; set; }

        public IEnumerable<SelectListItem> ActionsList { get; set; }
    }
}
