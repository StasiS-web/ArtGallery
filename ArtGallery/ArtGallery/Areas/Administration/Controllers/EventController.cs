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

            var events = allEvents.Select(x => new AllEventListViewModel()
            {
                Date = x.Date.ToString(),
                Description = x.Description,
                EventId = x.EventId,
                Name = x.Name,
                Price = x.Price,
                TicketSelection = x.TicketSelection,
                Type = x.Type,
            }).ToList();
            return View(events);
        }

        [HttpGet("Administration/Event/Edit")]
        public async Task<IActionResult> Edit(int eventId)
        {
            var model = await this.eventService.GetEventDetailsByIdAsync<EventEditViewModel>(eventId);
            var viewModel = new EventEditViewModel();
            viewModel.EventId = model.EventId;
            viewModel.Name = model.Name;
            viewModel.Date = model.Date.ToString();
            viewModel.Price = model.Price;
            viewModel.Description = model.Description;
            viewModel.TicketSelection = model.TicketSelection;
            viewModel.Type = model.Type;
            return View(viewModel);
        }

        [HttpPost("Administration/Event/Edit")]
        public IActionResult Edit(EventEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
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
