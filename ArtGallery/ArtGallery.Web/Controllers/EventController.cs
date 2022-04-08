using System.Globalization;
using System.Runtime.Serialization;
using ArtGallery.Data.Models.Enumeration;
using ArtGallery.Web.ViewModels.BlogPosts;
using ArtGallery.Web.ViewModels.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ArtGallery.Common.GlobalConstants.Formating;

namespace ArtGallery.Web.Controllers
{
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
        public IActionResult EventDetails([ModelBinder(typeof(DateTimeModelBinder))] int eventId)
        {
            if (eventId == null)
            {
                return new StatusCodeResult(404);
            }

            var eventDetails = this.events.GetEventDetailsByIdAsync<EventViewModel>(eventId);

            return this.View(eventDetails);
        }
    }
}
