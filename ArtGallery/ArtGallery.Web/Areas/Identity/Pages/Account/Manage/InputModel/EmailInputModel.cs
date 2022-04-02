using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Web.Areas.Identity.Pages.Account.Manage.InputModel
{
    public class EmailInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "New email")]
        public string NewEmail { get; set; }
    }
}
