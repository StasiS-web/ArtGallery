using ArtGallery.Core.Models.Administrator;
using ArtGallery.Core.Models.Events;
using ArtGallery.Infrastructure.Data.Models.Enumeration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Event = ArtGallery.Infrastructure.Data.Models.Event;

namespace ArtGallery.Areas.Administration.Controllers
{
    public class EventController : AdministrationController
    {
        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> AllEvent(int id)
        {
            var events = eventService.GetEventDetailsByIdAsync<EventViewModel>(id);
        
            return View(events);
        }
    }
}
