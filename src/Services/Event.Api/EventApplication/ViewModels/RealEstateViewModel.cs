using EventCore.Enums;

namespace EventApplication.ViewModels
{
    /// <summary>
    /// ViewModel for representing event properties.
    /// </summary>
    public class EventViewModel
    {
        /// <summary>
        /// The unique identifier of the event property.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title or name of the event property.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The status of the event property.
        /// </summary>
        public EventStatus Status { get; set; }

        /// <summary>
        /// The price of the event property.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The floor number of the event property (if applicable).
        /// </summary>
        public int Floor { get; set; }
    }
}
