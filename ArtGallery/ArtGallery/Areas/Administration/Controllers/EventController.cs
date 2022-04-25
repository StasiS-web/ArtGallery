namespace ArtGallery.Areas.Administration.Controllers
{
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Events;
    using Microsoft.AspNetCore.Mvc;

    public class EventController : AdministrationController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult All(int eventId)
        {
            var allEvents = this.eventService.GetAllEvents(eventId);

            return View(allEvents);
        }

        public IActionResult Edit(int eventId)
        {
            var model = this.eventService.GetEventDetailsByIdAsync<EventEditViewModel>(eventId);

            return View(model);
        }

        [HttpPost("/Event/Edit")]
        public IActionResult Edit(EventEditViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return new StatusCodeResult(404);
            }

            this.eventService.UpdateEventAsync(model);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int eventId)
        {
            this.eventService.Delete(eventId);

            return RedirectToAction(nameof(All));
        }

    }
}
