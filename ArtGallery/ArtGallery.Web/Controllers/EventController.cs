using ArtGallery.Web.ViewModels.Events;
using Microsoft.AspNetCore.Mvc;
using Event = ArtGallery.Data.Models.Event;

namespace ArtGallery.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService events;

        public EventController(IEventService eventservice)
        {
            this.events = eventservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{eventId}/Event")]
        public IActionResult GetListAllEvents(int eventId)
        {
            var allEvents = this.events.GetAllEvents(eventId);

            return View(allEvents);
        }

        [HttpPost]
        public IActionResult GetListAllEvents(AllEventListViewModel model)
        {
            return Ok(model);
        }

        [HttpGet("{eventId}")]
        public IActionResult GetOnce([FromRoute] int eventId)
        {
            return this.Redirect($"/Event/Index/{eventId}");
        }
    }
}
