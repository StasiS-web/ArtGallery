using System;
using ArtGallery.Data.Models.Enumeration;
using ArtGallery.Services.Data.Administrator.Contracts;
using ArtGallery.Web.Helper;
using ArtGallery.Web.ViewModels.Administrator;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class EventController : BaseController
    {
        private readonly IAdminEventService adminEventService;
        private readonly IEventService eventService;

        public EventController(IAdminEventService adminEventService, IEventService eventService)
        {
            this.adminEventService = adminEventService;
            this.eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEvents(EventCreateInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await adminEventService.CreateEventAsync(model))
            {
                ViewData[MessageConstants.OperationalMessages] = "Succefully Written Down";
            }
            else
            {
                ViewData[MessageConstants.OperationalMessages] = "Oops! An error occurred.";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventEditViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await adminEventService.UpdateEventAsync(model))
            {
                ViewData[MessageConstants.OperationalMessages] = "Succefully Written Down";
            }
            else
            {
                ViewData[MessageConstants.OperationalMessages] = "Oops! An error occurred.";
            }

            return View(model);
        }

        public IActionResult ActionType()
        {
            var model = new EventEditViewModel();
            return View(model);
        }
    }
}
