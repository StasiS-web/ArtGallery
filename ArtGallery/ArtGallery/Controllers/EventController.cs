namespace ArtGallery.Controllers
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.Events;
    using ArtGallery.ModelBinders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventController : BaseController
    {
        private readonly IEventService events;

        public EventController(IEventService eventservice)
        {
            this.events = eventservice;
        }

        [Route("/Event/AllEvents")]
        [AllowAnonymous]
        public IActionResult AllEvents(AllEventListViewModel model)
        {
            var modelView = this.events.GetAllEvents(model.EventId)
                .Select(e => new AllEventListViewModel
                {
                    Name = model.Name,
                    Date = model.Date,
                    Type = model.Type,
                    Description = model.ShortDescription,
                }).ToList();

            return View(modelView);
        }

        [Route("/Event/EventDetails/{eventId}")]
        public IActionResult EventDetails(int eventId)
        {
            if (eventId == null)
            {
                return new StatusCodeResult(404);
            }

            var eventDetails = this.events.GetEventDetailsByIdAsync<EventViewModel>(eventId);

            return this.View(eventDetails);
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    SameSite = SameSiteMode.Strict
                });

            return LocalRedirect(returnUrl);
        }
    }
}
