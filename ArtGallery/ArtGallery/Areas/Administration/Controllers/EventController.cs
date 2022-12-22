namespace ArtGallery.Areas.Administration.Controllers
{
    using ArtGallery.Core.Models.Administrator;
    using ArtGallery.Core.Models.Events;
    using Microsoft.AspNetCore.Mvc;

    // Code changes by behaviour.
    public class EventController : AdministrationController
    {
        private readonly IEventService eventService;
        private readonly UserManager<ApplicationUser> userManager;

        public EventController(IEventService eventService, UserManager<ApplicationUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }
        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EventCreateInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await eventService.CreateEventAsync(model);
            return Redirect("All");
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
                })
                .ToList();
            ViewBag.events = events.ToList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int eventId)
        {
            var model = await this.eventService.GetEventDetailsByIdAsync<EventViewModel>(eventId);
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

        [HttpPost]
        public IActionResult Edit(EventEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.eventService.UpdateEventAsync(model);

            return RedirectToAction("All", "Event", new { area = "Administration" });
        }

        public async Task<IActionResult> Delete(int eventId)
        {
            this.eventService.Delete(eventId);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int eventId, EventViewModel model)
        {
            var exists = await this.eventService.CheckIfEventExists(eventId);

            if (!exists)
            {
                return View(model);
            }

            this.eventService.Delete(eventId);

            return RedirectToAction("All", "Event", new {area = "Administration"});
        }

    }
}
