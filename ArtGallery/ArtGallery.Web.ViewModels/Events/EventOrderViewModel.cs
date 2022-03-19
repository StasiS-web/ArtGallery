namespace ArtGallery.Web.ViewModels.Events
{
    using System;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Services.Mapping.Contracts;

    public class EventOrderViewModel : IMapFrom<EventOrder>
    {
        public string BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int EventId { get; set; }

        public string Event { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // Gallery should confirm the place of the user on the event. It depends from the available capacity for the event.
        public bool? Confirmed { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
