using Commons.Models;
using EventCore.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EventCore.Models
{
    /// <summary>
    /// Represents a event property.
    /// </summary>
    public class Event : BaseModel
    {
        /// <summary>
        /// The unique identifier of the event property.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }

        /// <summary>
        /// The title or name of the event property.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The current status of the event property.
        /// </summary>
        public EventStatus Status { get; set; }

        /// <summary>
        /// The price of the event property.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The Latitude number of the event property 
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// The Longitude number of the event property 
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// The Address of the event property 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The list of change logs associated with the event property.
        /// </summary>
        public virtual List<ChangeLog> ChangeLogs { get; set; } = new List<ChangeLog>();

        public int CatetoryId { get; set; }

        public Category Category { get; set; }
    }
}
