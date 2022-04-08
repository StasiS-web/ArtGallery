using System;
using ArtGallery.Data.Models.Enumeration;
using ArtGallery.Web.Helper;
using ArtGallery.Web.ViewModels.Administrator;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Web.Areas.Administration.Controllers
{
    public class EventController : AdministrationController
    {
        private readonly IEventService adminService;

        public EventController(IEventService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Event/CreateEvent")]
        public async Task<IActionResult> CreateEvent([ModelBinder(typeof(DecimalModelBinder))] EventCreateInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await adminService.CreateEventAsync(model))
            {
                ViewData[MessageConstants.OperationalMessage] = "Succefully Written Down";
            }
            else
            {
                ViewData[MessageConstants.OperationalMessage] = "Oops! An error occurred.";
            }

            return View(model);
        }

        [HttpPost("EditEvent")]
        public async Task<IActionResult> EditEvent([ModelBinder(typeof(DecimalModelBinder))] EventEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await adminService.UpdateEventAsync(model))
            {
                ViewData[MessageConstants.OperationalMessage] = "Succefully Written Down";
            }
            else
            {
                ViewData[MessageConstants.OperationalMessage] = "Oops! An error occurred.";
            }

            return View(model);
        }
    }
}
