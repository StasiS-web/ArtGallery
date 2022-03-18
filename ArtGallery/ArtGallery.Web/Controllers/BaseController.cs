using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
